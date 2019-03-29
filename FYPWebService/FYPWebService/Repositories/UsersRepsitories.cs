using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FYPWebService.Models;

namespace FYPWebService.Repositories
{
    public class UsersRepsitories
    {
        public static bool ReadLoginToDB(Login login)
        {
            var connectionString = "Server = tcp:fypfb.database.windows.net,1433; Initial Catalog = FYPMadan; Persist Security Info = False; User ID = Madanthapa; Password =Ninjamaster1; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
            var query = "SELECT COUNT(*) FROM Login WHERE(UserName = @Username && Password = @Password)";
            query = query.Replace("@Username", login.Username)
                .Replace("@Password", login.Password);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                //command.ExecuteNonQuery();
                //command.Dispose();
                //connection.Close();
                //return true;
                int UserExist = (int)command.ExecuteScalar();

                if (UserExist > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}