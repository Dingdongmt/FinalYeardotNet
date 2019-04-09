using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FYPWebService.Models;
using System.Data;
using System.Collections;

namespace FYPWebService.Repositories
{
    public class UsersRepsitories
    {
        public static object ReadLoginToDB(Login login)
        {
            var connectionString = "Server = tcp:friendlybunch.database.windows.net,1433;" +
                " Initial Catalog = FPYSQl; Persist Security Info = False;" +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "SELECT * From loginDetails WHERE UserName = '@Username' AND Password = '@Password'";
                        query = query.Replace("@Username", login.Username)
                            .Replace("@Password", login.Password);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                var UserExist = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (UserExist.Read())
                {
                    var UserId = String.Format("{0}", UserExist[0]);
                    var Username = String.Format("{0}", UserExist[1]);
                    var type = String.Format("{0}", UserExist[2]);
                    var Password = String.Format("{0}", UserExist[3]);
                    var GroupId = String.Format("{0}", UserExist[4]);
                    object repobject = new { UserId, type, GroupId };
                    if (Username != null)
                    {
                        if (Username == login.Username & Password == login.Password)
                        {
                            connection.Close();
                            return repobject;
                        }
                        else
                        {
                            connection.Close();
                            return "false";
                        }
                    }

                    else
                    {
                        return "false";
                    }
                }
                return "false";
            }
            catch (Exception)
            {
                throw;           }
        }


        public static object GetProfileDetails(Profile profile)
        {
            var connectionString = "Server = tcp:friendlybunch.database.windows.net,1433;" +
                " Initial Catalog = FPYSQl; Persist Security Info = False;" +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "SELECT * From ProfileDetails WHERE UserId = @UserId";
            query = query.Replace("@UserId", profile.UserId);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                var UserExist = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (UserExist.Read())
                {
                    var UserId = String.Format("{0}", UserExist[0]);
                    var Name = String.Format("{0}", UserExist[1]);
                    var Admin = String.Format("{0}", UserExist[2]);
                    var Bio = String.Format("{0}", UserExist[3]);
                    var NickName = String.Format("{0}", UserExist[4]);
                    var GroupId = String.Format("{0}", UserExist[5]);
                    var GroupName = String.Format("{0}", UserExist[6]);
                    var Address1 = String.Format("{0}", UserExist[7]);
                    var Address2 = String.Format("{0}", UserExist[8]);
                    var Town = String.Format("{0}", UserExist[9]);
                    var County = String.Format("{0}", UserExist[10]);
                    var Country = String.Format("{0}", UserExist[11]);
                    var PostCode = String.Format("{0}", UserExist[12]);
                    object repobject= new { UserId,  Name ,  Admin , Bio, NickName, GroupId, GroupName ,  Address1, Address2,  Town ,  County,  Country ,  PostCode };
                    if (UserId != null)
                    {
                        connection.Close();
                        return repobject;
 
                    }

                    else
                    {
                        connection.Close();
                        return "false";
                    }
                }
                connection.Close();
                return "false";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object GetSignup(Signup signup)
        {
            var connectionString = "Server = tcp:friendlybunch.database.windows.net,1433;" +
                " Initial Catalog = FPYSQl; Persist Security Info = False;" +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";

            var query = "DECLARE @loginid int, @address int, @groupid int" +
                "INSERT INTO [Login](UserName, Password, Type) VALUES(@UserName, @Password, 1) set @loginid = SCOPE_IDENTITY()" +
                "INSERT INTO [Address](AddressLine1, AddressLine2, County, Country, PostCode) VALUES(@Address1, @Address2, @County, @Country, @PostCode) set @address = SCOPE_IDENTITY()" +
                "INSERT INTO [Group](LoginId, AddressId, Name) VALUES(@loginid, @address, @GroupName) set @groupid = SCOPE_IDENTITY()" +
                "INSERT INTO [User](LoginId, GroupId, Name, Admin, Boi)VALUES(@loginid, @groupid, @Name, 1, @Bio);";


        query = query.Replace("@Name", signup.Name)
            .Replace("@Bio", signup.Bio)
            .Replace("@UserName", signup.UserName)
            .Replace("@Password", signup.Password)
            .Replace("@GroupName", signup.GroupName)
            .Replace("@GroupBio", signup.GroupBio)
            .Replace("@Address1", signup.Address1)
            .Replace("@Address2", signup.Address2)
            .Replace("@County", signup.County)
            .Replace("@Country", signup.Country)
            .Replace("@PostCode", signup.PostCode);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                // Check Error
                command.ExecuteNonQuery();
                connection.Close();
                return "True";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object GetGroupUser(GroupUser groupUser)
        {
            var connectionString = "Server = tcp:friendlybunch.database.windows.net,1433;" +
                " Initial Catalog = FPYSQl; Persist Security Info = False;" +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "SELECT * From [User] WHERE GroupId = '@GroupId'";
            query = query.Replace("@GroupId", groupUser.GroupId);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                ArrayList repoArray = new ArrayList();
                SqlCommand command = new SqlCommand(query, connection);
                var UserExist = command.ExecuteReader();
                while  (UserExist.Read())
                {
                    var UserId = UserExist.GetInt32(0);
                    var LoginId = UserExist.GetInt32(1);
                    var GroupId = UserExist.GetInt32(2);
                    var Name = UserExist.GetString(3);
                    var Admin = UserExist.GetBoolean(4);
                    var Bio = UserExist.GetString(5);
                    var NickName = UserExist.GetString(6);
                    object user = new { UserId , LoginId , GroupId , Name , Admin , Bio , NickName };
                    repoArray.Add(user);
                }
                return repoArray;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}