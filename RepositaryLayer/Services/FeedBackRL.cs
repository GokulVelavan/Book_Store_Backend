using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model.BookModel;
using CommonLayer.Model.FeedBackModel;
using RepositaryLayer.Interfaces;

namespace RepositaryLayer.Services
{
    public class FeedBackRL: IFeedBackRL
    {
        public static string connectionString = "server=DESKTOP-7VR0RDR\\SQLEXPRESS;database=Book;User ID=gokulvelavan;password=gokulvelavan;";

        SqlConnection connection = new SqlConnection(connectionString);
        public FeedBackResponseModel AddFeedBack(long bookId, AddFeedBackModel model, long jwtUserId)
        {
            try
            {
                SqlConnection sqlConnection = new(connectionString);
                string query = "select BookId,UserId from Books where BookId=@BookId and UserId=@UserId ";
                SqlCommand validateCommand = new(query, sqlConnection);
                BookCredentialModel validationModel = new();

                sqlConnection.Open();
                validateCommand.Parameters.AddWithValue("@BookId", bookId);
                validateCommand.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = validateCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        validationModel.BookId = Convert.ToInt32(reader["BookId"]);
                        validationModel.UserId = Convert.ToInt32(reader["UserId"]);
                    }
                    using (connection)
                    {
                        SqlCommand command = new("spAddFeedBack", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookId", validationModel.BookId);
                        command.Parameters.AddWithValue("@FeedBack", model.FeedBack);
                        command.Parameters.AddWithValue("@Ratings", model.Ratings);
                        command.Parameters.AddWithValue("@UserId", validationModel.UserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            FeedBackResponseModel response = new()
                            {
                                BookId = validationModel.BookId,
                                FeedBack = model.FeedBack,
                                Ratings = model.Ratings,
                                UserId = validationModel.UserId
                            };
                            return response;
                        }
                    }
                }
                sqlConnection.Close();
                return null;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }


    }
}
