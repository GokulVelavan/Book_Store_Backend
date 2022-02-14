using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model.BookModel;
using Microsoft.Extensions.Configuration;
using RepositaryLayer.Interfaces;

namespace RepositaryLayer.Services
{
    public class BookRL:IBookRL
    {
        public readonly IConfiguration config;

        public BookRL(IConfiguration config)
        {
            this.config = config;
        }

        public static string connectionString = "server=DESKTOP-7VR0RDR\\SQLEXPRESS;database=Book;User ID=gokulvelavan;password=gokulvelavan;";

        SqlConnection connection = new SqlConnection(connectionString);
        public BookResponseModel CreateBookDetails(CreateBookModel model, long jwtUserId)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new("SPAddBook", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookName", model.BookName);
                    command.Parameters.AddWithValue("@BookAuthor", model.BookAuthor);
                    command.Parameters.AddWithValue("@OriginalPrice", model.OriginalPrice);
                    command.Parameters.AddWithValue("@DiscountPrice", model.DiscountPrice);
                    command.Parameters.AddWithValue("@BookQuantity", model.BookQuantity);
                    command.Parameters.AddWithValue("@BookDetails", model.BookDetails);
                    command.Parameters.AddWithValue("@UserId", jwtUserId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result >= 0)
                    {
                        BookResponseModel response = new()
                        {
                            BookName = model.BookName,
                            BookAuthor = model.BookAuthor,
                            OriginalPrice = model.OriginalPrice,
                            DiscountPrice = model.DiscountPrice,
                            BookQuantity = model.BookQuantity,
                            BookDetails = model.BookDetails,
                            UserId = jwtUserId
                        };
                        return response;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
        public bool DeletetBookByBookId(long bookId, long jwtUserId)
        {
            try
            {
                SqlCommand command = new("SPDeleteBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@UserId", jwtUserId);

                this.connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this.connection.Close();
            }
        }
        public BookResponseModel GetBookById(long bookId, long jwtUserId)
        {
            try
            {
                BookResponseModel responseModel = new();
                SqlCommand command = new("SPGetBookWithBookId1", connection);
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        responseModel.BookId = Convert.ToInt32(reader["BookId"]);
                        responseModel.BookName = reader["BookName"].ToString();
                        responseModel.BookAuthor = reader["BookAuthor"].ToString();
                        responseModel.TotalRating = Convert.ToInt32(reader["TotalRating"] == DBNull.Value ? default : reader["TotalRating"]);
                        responseModel.NoOfPeopleRated = Convert.ToInt32(reader["NoOfPeopleRated"] == DBNull.Value ? default : reader["NoOfPeopleRated"]);
                        responseModel.OriginalPrice = Convert.ToInt32(reader["OriginalPrice"] == DBNull.Value ? default : reader["OriginalPrice"]);
                        responseModel.DiscountPrice = Convert.ToInt32(reader["DiscountPrice"] == DBNull.Value ? default : reader["DiscountPrice"]);
                        responseModel.BookImage = reader["BookImage"].ToString();
                        responseModel.BookQuantity = Convert.ToInt32(reader["BookQuantity"] == DBNull.Value ? default : reader["BookQuantity"]);
                        responseModel.BookDetails = reader["BookDetails"].ToString();
                        responseModel.UserId = Convert.ToInt32(reader["UserId"]);
                    }
                    return responseModel;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {
                this.connection.Close();
            }
        }
        public BookResponseModel UpdateBookDetails(long bookId, UpdateBookModel model, long jwtUserId)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new("SPUpdateBook1", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@BookName", model.BookName);
                    command.Parameters.AddWithValue("@BookAuthor", model.BookAuthor);
                    command.Parameters.AddWithValue("@OriginalPrice", model.OriginalPrice);
                    command.Parameters.AddWithValue("@DiscountPrice", model.DiscountPrice);
                    command.Parameters.AddWithValue("@BookQuantity", model.BookQuantity);
                    command.Parameters.AddWithValue("@BookDetails", model.BookDetails);
                    command.Parameters.AddWithValue("@UserId", jwtUserId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    BookResponseModel model1 = new BookResponseModel();
                   
                    if (result >= 0)
                    {
                        return GetBookById(bookId,jwtUserId);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }


    }
}
