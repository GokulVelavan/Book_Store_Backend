using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model.CartModel;
using RepositaryLayer.Interfaces;

namespace RepositaryLayer.Services
{
    public class CartRL:ICartRL
    {
        public static string connectionString = "server=DESKTOP-7VR0RDR\\SQLEXPRESS;database=Book;User ID=gokulvelavan;password=gokulvelavan;";

        SqlConnection connection = new SqlConnection(connectionString);
        public CartResponseModel CreateCartDetails(AddCartModel model,long BookId, long jwtUserId)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new("SPAddCart", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookId", BookId);
                    command.Parameters.AddWithValue("@Quantity ", model.Quantity);
                    command.Parameters.AddWithValue("@UserId", jwtUserId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result >= 0)
                    {
                        CartResponseModel response = new()
                        {
                            Quantity = model.Quantity,
                            BookId=BookId,
                            UserId = jwtUserId
                        };
                        return response;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeletetCArtById(long CartId, long jwtUserId)
        {
            try
            {
                SqlCommand command = new("SPDeleteCart", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CartId", CartId);
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

    }
}
