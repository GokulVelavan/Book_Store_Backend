using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model.UserModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositaryLayer.Interfaces;

namespace RepositaryLayer.Services
{
    public class UserRL:IUserRL
    {
        public readonly IConfiguration config;

        public UserRL(IConfiguration config)
        {
            this.config = config;
        }
        public static string connectionString = "server=DESKTOP-7VR0RDR\\SQLEXPRESS;database=Book;User ID=gokulvelavan;password=gokulvelavan;";

        SqlConnection connection = new SqlConnection(connectionString);

        public string JwtTokenGenerate(string email, long userId)
        {
            try
            {
                var loginTokenHandler = new JwtSecurityTokenHandler();
                var loginTokenKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.config[("Jwt:key")]));
                var loginTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, email),
                        new Claim("UserId",userId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(loginTokenKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = loginTokenHandler.CreateToken(loginTokenDescriptor);
                return loginTokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string EncryptingPassword(string password)
        {
            try
            {
                byte[] encptPass = new byte[password.Length];
                encptPass = Encoding.UTF8.GetBytes(password);
                string encrypted = Convert.ToBase64String(encptPass);
                return encrypted;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public SignUpResponse Signup(SignUpModel model)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SPAddUser", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FullName", model.FullName);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Password", EncryptingPassword(model.Password));
                    command.Parameters.AddWithValue("@MobileNumber", model.MobileNumber);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result >= 0)
                    {
                        SignUpResponse response = new()
                        {
                            FullName = model.FullName,
                            Email = model.Email,
                            MobileNumber = model.MobileNumber
                        };
                        return response;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Login(LoginModel model)
        {
            try
            {
                using (connection)
                {
                    UserModel detail = new UserModel();
                    
                    SqlCommand command = new SqlCommand("SPLoginUser", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    this.connection.Open();
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Password", EncryptingPassword(model.Password));

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            detail.UserId = Convert.ToInt32(reader["UserId"] == DBNull.Value ? default : reader["UserId"]);
                            detail.Email = Convert.ToString(reader["Email"] == DBNull.Value ? default : reader["Email"]);
                            detail.Password = Convert.ToString(reader["Password"] == DBNull.Value ? default : reader["Password"]);
                        }
                        string token = JwtTokenGenerate(detail.Email, detail.UserId);
                        return token;
                    }
                    return null;
                }
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
        public string ForgetPassword(ForgetPasswordModel model)
        {
            try
            {
                using (connection)
                {
                    UserModel detail = new UserModel();

                    SqlCommand command = new SqlCommand("SPForgetPassword", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    this.connection.Open();
                    command.Parameters.AddWithValue("@Email", model.Email);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            detail.Email = Convert.ToString(reader["Email"] == DBNull.Value ? default : reader["Email"]);
                            //detail.UserId = Convert.ToInt32(reader["UserId"] == DBNull.Value ? default : reader["UserId"]);
                        }
                        string token = JwtTokenGenerate(detail.Email, 2);
                        //new MsMqModel().MsmqSender(token);
                        return token;
                    }
                    return null;
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
        public bool ResetPassword(ResetPasswordModel model, string email)
        {
            try
            {
                using (connection)
                {
                    if (model.Password == model.ConfirmPassword)
                    {
                        SqlCommand command = new SqlCommand("SPResetPassword", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", EncryptingPassword(model.Password));
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
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
    }
}
