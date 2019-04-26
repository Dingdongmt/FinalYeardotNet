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
                    var AddressId = String.Format("{0}", UserExist[7]);
                    var Address1 = String.Format("{0}", UserExist[8]);
                    var Address2 = String.Format("{0}", UserExist[9]);
                    var County = String.Format("{0}", UserExist[10]);
                    var Country = String.Format("{0}", UserExist[11]);
                    var PostCode = String.Format("{0}", UserExist[12]);
                    var LoginId = String.Format("{0}", UserExist[13]);
                    var UserName = String.Format("{0}", UserExist[14]);
                    var Password = String.Format("{0}", UserExist[15]);
                    object repobject= new { UserId,  Name ,  Admin , Bio, NickName, GroupId, GroupName , AddressId,  Address1, Address2, County,  Country ,  PostCode, LoginId, UserName,Password };
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

        public static object UpdateProfile(UpProfile upProfile)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";

            var query = " UPDATE [Login] SET UserName = '@UserName', Password = '@Password' WHERE LoginId = @LoginId;" +
                " UPDATE [Address] SET AddressLine1='@Address1', AddressLine2='@Address2', County='@County', Country='@Country', PostCode='@PostCode' WHERE AddressId = @AddressId;" +
                " UPDATE [Group] SET Name='@GroupName' WHERE GroupId = @GroupId;" +
                " UPDATE [User] SET LoginId='@LoginId', GroupId='@GroupId', Name='@Name', Bio='@Bio', NickName='@NickName' WHERE UserId = @UserId;";


            query = query.Replace("@UserId", upProfile.UserId)
                .Replace("@Name", upProfile.Name)
                .Replace("@NickName", upProfile.NickName)
                .Replace("@Bio", upProfile.Bio)
                .Replace("@LoginId", upProfile.LoginId)
                .Replace("@UserName", upProfile.UserName)
                .Replace("@Password", upProfile.Password)
                .Replace("@GroupId", upProfile.GroupId)
                .Replace("@GroupName", upProfile.GroupName)
                .Replace("@GroupBio", upProfile.GroupBio)
                .Replace("@AddressId", upProfile.AddressId)
                .Replace("@Address1", upProfile.Address1)
                .Replace("@Address2", upProfile.Address2)
                .Replace("@County", upProfile.County)
                .Replace("@Country", upProfile.Country)
                .Replace("@PostCode", upProfile.PostCode);
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

        public static object GetSignup(Signup signup)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";

            var query = "DECLARE @loginid int, @address int, @groupid int" +
                " INSERT INTO [Login](UserName, Password, Type) VALUES('@UserName', '@Password', 1) set @loginid = SCOPE_IDENTITY()" +
                " INSERT INTO [Address](AddressLine1, AddressLine2, County, Country, PostCode) VALUES('@Address1',' @Address2', '@County', '@Country', '@PostCode') set @address = SCOPE_IDENTITY()" +
                " INSERT INTO [Group](AddressId, Name) VALUES(@address, '@GroupName') set @groupid = SCOPE_IDENTITY()" +
                " INSERT INTO [User](LoginId, GroupId, Name, Admin, Bio)VALUES(@loginid, @groupid, '@Name', 1, '@Bio');";


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

        public static object AddUsers(AddUser addUser)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";

            var query = "DECLARE @loginid int" +
                " INSERT INTO [Login](UserName, Password, Type) VALUES('@UserName', '@Password', 0) set @loginid = SCOPE_IDENTITY()" +
                " INSERT INTO [User](LoginId, GroupId, Name, Admin) VALUES(@loginid, @GroupId, '@Name', 0);";


            query = query.Replace("@Name", addUser.Name)
                .Replace("@UserName", addUser.UserName)
                .Replace("@Password", addUser.Password)
                .Replace("@GroupId", addUser.GroupId);
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
                    var UserId = String.Format("{0}", UserExist[0]);
                    var LoginId = String.Format("{0}", UserExist[1]);
                    var GroupId = String.Format("{0}", UserExist[2]);
                    var Name = String.Format("{0}", UserExist[3]);
                    var Admin = String.Format("{0}", UserExist[4]);
                    var Bio = String.Format("{0}", UserExist[5]);
                    var NickName = String.Format("{0}", UserExist[6]);
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

        public static object GetPostinfo(Postinfo postinfo)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "SELECT * From [Post]";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                ArrayList repoArray = new ArrayList();
                SqlCommand command = new SqlCommand(query, connection);
                var UserExist = command.ExecuteReader();
                while (UserExist.Read())
                {
                    var PostId = String.Format("{0}", UserExist[0]);
                    var UserId = String.Format("{0}", UserExist[1]);
                    var Container = String.Format("{0}", UserExist[2]);
                    var SentTime = String.Format("{0}", UserExist[3]);
                    object user = new { PostId, UserId, Container, SentTime };
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

        public static object InsertComment(PostComment postComment)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "INSERT INTO [Comment](UserId, PostId, Container, SentTime) VALUES('@UserId', '@PostId', '@Container', GETDATE())";
            query = query.Replace("@UserId", postComment.UserId)
                .Replace("@PostId", postComment.PostId)
                .Replace("@Container", postComment.Container);

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

        public static object GetFilters(Filters filters)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";

            var query = "SELECT * FROM [Reported]";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                ArrayList repoArray = new ArrayList();
                SqlCommand command = new SqlCommand(query, connection);
                var UserExist = command.ExecuteReader();
                while (UserExist.Read())
                {
                    var Total = UserExist.GetInt32(0);
                    var Word = String.Format("{0}", UserExist[1]);
                    if (Total >= 5)
                    {
                        repoArray.Add(Word);
                    }
                }
                return repoArray;
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
                query = "DELETE FROM[Comment] WHERE CommentId = '@PCId'";
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

        public static object ReportPost(ReportPost reportPost)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";

            var query = "INSERT INTO [Censor](Word) VALUES('@PCId')";
                query = query.Replace("@PCId", reportPost.BadWord);

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
            var query = "select * From [chatInfo] WHERE GroupId = '@GroupId' ORDER BY ChatId";
            query = query.Replace("@GroupId", chat.GroupId);

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

                    object user = new { ChatId, UserId, GroupId, SenderId, RecipientId, Container, SentTime};
                    repoArray.Add(user);
                }
                connection.Close();
                return repoArray;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object GetChat(ChatInfo chatInfo)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = True; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";
            var query = "select * From [Chat]";

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
                    var RecipientId = String.Format("{0}", UserExist[2]);

                    object user = new { ChatId, UserId, RecipientId };
                    repoArray.Add(user);
                }
                connection.Close();
                return repoArray;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object Postchat(Message message)
        {
            var connectionString = "Server = tcp:fypbunch.database.windows.net,1433; " +
                "Initial Catalog = FYPFriendly; Persist Security Info = False; " +
                " User ID = Q5030168; Password =Ninjamaster1; " +
                "MultipleActiveResultSets = False; Encrypt = True; " +
                "TrustServerCertificate = False; Connection Timeout = 30";

        var query = "DECLARE @chatid int" +
                " INSERT INTO [Chat](SenderId, RecipientId) VALUES('@UserId', '@RecipientId') set @chatid = SCOPE_IDENTITY()" +
                " INSERT INTO [Message](chatId, UserId, Container, sentTime) VALUES(@chatid,'@UserId','@Container',GETDATE())";

            query = query.Replace("@UserId", message.UserId)
                .Replace("@RecipientId", message.RecipientId)
                .Replace("@Container", message.Container);
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
    }
}