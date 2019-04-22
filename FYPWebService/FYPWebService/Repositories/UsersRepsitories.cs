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
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                "User ID = Q5030168; Password =Ninjamaster1; " +
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
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
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
                    var County = String.Format("{0}", UserExist[9]);
                    var Country = String.Format("{0}", UserExist[10]);
                    var PostCode = String.Format("{0}", UserExist[11]);
                    var UserName = String.Format("{0}", UserExist[12]);
                    var Password = String.Format("{0}", UserExist[13]);
                    object repobject= new { UserId,  Name ,  Admin , Bio, NickName, GroupId, GroupName ,  Address1, Address2, County,  Country ,  PostCode, UserName,Password };
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
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";

            var query = "DECLARE @loginid int, @address int, @groupid int" +
                "INSERT INTO [Login](UserName, Password, Type) VALUES('@UserName', '@Password', 1) set @loginid = SCOPE_IDENTITY()" +
                "INSERT INTO [Address](AddressLine1, AddressLine2, County, Country, PostCode) VALUES('@Address1', '@Address2', '@County', '@Country', '@PostCode') set @address = SCOPE_IDENTITY()" +
                "INSERT INTO [Group](LoginId, AddressId, Name) VALUES('@loginid', '@address', '@GroupName') set @groupid = SCOPE_IDENTITY()" +
                "INSERT INTO [User](LoginId, GroupId, Name, Admin, Boi)VALUES('@loginid', '@groupid', '@Name', 1, '@Bio');";


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
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
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

        public static object GetGroupUserDetail(GroupUserdetail groupUserdetail)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "SELECT Container, SentTime From[Post] WHERE UserId = '@UserId'  union SELECT Container, SentTime From[Comment] WHERE UserId = '@UserId'";
            query = query.Replace("@UserId", groupUserdetail.UserId);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                ArrayList repoArray = new ArrayList();
                SqlCommand command = new SqlCommand(query, connection);
                var UserExist = command.ExecuteReader();
                while (UserExist.Read())
                {
                    var Container = String.Format("{0}", UserExist[0]);
                    var SentTime = String.Format("{0}", UserExist[1]);
                    object user = new { Container, SentTime };
                    repoArray.Add(user);
                }
                return repoArray;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object GetPostDetails(PostDetails postDetails)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "SELECT * From [PostDetail] WHERE GroupId = '@GroupId'";
            query = query.Replace("@GroupId", postDetails.GroupId);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                ArrayList repoArray = new ArrayList();
                SqlCommand command = new SqlCommand(query, connection);
                var UserExist = command.ExecuteReader();
                while (UserExist.Read())
                {
                    var UserId = String.Format("{0}", UserExist[0]);
                    var GroupId = String.Format("{0}", UserExist[1]);
                    var NickName = String.Format("{0}", UserExist[2]);
                    var PostId = String.Format("{0}", UserExist[3]);
                    var Container = String.Format("{0}", UserExist[4]);
                    var SentTime = String.Format("{0}", UserExist[5]);
                    var CommentId = String.Format("{0}", UserExist[6]);
                    var CContainer = String.Format("{0}", UserExist[7]);
                    var CSentTime = String.Format("{0}", UserExist[8]);
                    var CCNickName = String.Format("{0}", UserExist[9]);
                    object user = new { UserId, GroupId, NickName, PostId, Container, SentTime, CommentId, CContainer, CSentTime, CCNickName };
                    repoArray.Add(user);
                }
                return repoArray;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static object InsertPostPost(PostPost postPost)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "INSERT INTO [Post](UserId, Container, SentTime) VALUES('@UserId', '@Container', GETDATE())";
            query = query.Replace("@UserId", postPost.UserId)
                .Replace("@Container", postPost.Container);

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

        public static object DeletePost(DeletePost deletepost)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "";
            if(deletepost.PCType == "Post")
            {
                query = "DELETE FROM[Post] WHERE PostId = '@PCId'";
                query = query.Replace("@PCId", deletepost.PCId);
            } else
            {
                query = "DELETE FROM[Comment] WHERE PostId = '@PCId'";
                query = query.Replace("@PCId", deletepost.PCId);
            }
            
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

        public static object GetChatInfo(Chat chat)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = True; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "select * From [chatInfo] WHERE UserId = '@UserId'";
            query = query.Replace("@UserId", chat.UserId);

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                ArrayList repoArray = new ArrayList();
                SqlCommand command = new SqlCommand(query, connection);
                var UserExist = command.ExecuteReader();
                while (UserExist.Read())
                {
                    var ChatId = String.Format("{0}", UserExist[0]);
                    var UserId = String.Format("{0}", UserExist[1]);
                    var GroupId = String.Format("{0}", UserExist[2]);
                    var SenderId = String.Format("{0}", UserExist[3]);
                    var RecipientId = String.Format("{0}", UserExist[4]);
                    var Container = String.Format("{0}", UserExist[5]);
                    var SentTime = String.Format("{0}", UserExist[6]);
                    var Sender = "";
                    var Recipient = "";

                    var querygetname = "select Name from [User] where UserId = @Sender union select Name from [User] where UserId = @Reciver";
                    querygetname = querygetname.Replace("@Sender", SenderId)
                        .Replace("@Reciver", RecipientId);
                    SqlCommand command1 = new SqlCommand(querygetname, connection);
                    var checkname = command1.ExecuteReader();
                    while (checkname.Read())
                    {
                        Sender = String.Format("{0}", checkname[0]);
                        Recipient = String.Format("{0}", checkname[1]);
                        object user = new { ChatId, UserId, GroupId, Container, SentTime };
                        repoArray.Add(user);
                    }
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