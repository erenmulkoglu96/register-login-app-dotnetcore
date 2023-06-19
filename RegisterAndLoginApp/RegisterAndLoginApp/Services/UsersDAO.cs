using static System.Net.Mime.MediaTypeNames;
using System;
using RegisterAndLoginApp.Models;
using Microsoft.Data.SqlClient;

namespace RegisterAndLoginApp.Services
{
    public class UsersDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";


        public bool FindUserByNameAndPassword(UserModel user)

        {
            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);


                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try 
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) {

                        success = true;
                    }
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            return success;

            // return true Eğer DB bulursan
        }
    }
}
