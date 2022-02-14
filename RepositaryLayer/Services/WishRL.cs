using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositaryLayer.Interfaces;

namespace RepositaryLayer.Services
{
    public class WishRL:IWishRL
    {
         public static string connectionString = "server=DESKTOP-7VR0RDR\\SQLEXPRESS;database=Book;User ID=gokulvelavan;password=gokulvelavan;";

        SqlConnection connection = new SqlConnection(connectionString);

        public bool AddWishList(long bookId, long jwtUserId)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new("SPAddWishlist", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@UserId", jwtUserId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result >= 0)
                    {
                        
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool RemoveWishList(long WishlistId, long jwtUserId)
        {
            try
            {
                SqlCommand command = new("SPDeleteWish", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@WishlistId", WishlistId);
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
