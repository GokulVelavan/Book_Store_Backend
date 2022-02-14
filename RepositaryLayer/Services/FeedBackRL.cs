using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Services
{
    public class FeedBackRL
    {
        public static string connectionString = "server=DESKTOP-7VR0RDR\\SQLEXPRESS;database=Book;User ID=gokulvelavan;password=gokulvelavan;";

        SqlConnection connection = new SqlConnection(connectionString);
        //public CartResponseModel CreateFeedBackDetails(AddCartModel model, long BookId, long jwtUserId)
        //{
        //    try
        //    {
        //        using (connection)
        //        {
        //            SqlCommand command = new("SPAddCart", connection);
        //            command.CommandType = CommandType.StoredProcedure;

        //            command.Parameters.AddWithValue("@BookId", BookId);
        //            command.Parameters.AddWithValue("@Quantity ", model.Quantity);
        //            command.Parameters.AddWithValue("@UserId", jwtUserId);
        //            this.connection.Open();
        //            int result = command.ExecuteNonQuery();
        //            this.connection.Close();
        //            if (result >= 0)
        //            {
        //                CartResponseModel response = new()
        //                {
        //                    Quantity = model.Quantity,
        //                    BookId = BookId,
        //                    UserId = jwtUserId
        //                };
        //                return response;
        //            }
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

    }
}
