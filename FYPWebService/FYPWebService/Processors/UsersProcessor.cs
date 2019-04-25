using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYPWebService.Models;
using FYPWebService.Repositories;

namespace FYPWebService.Processors
{
    public class LoginProcessor
    {
        public static object ProcessUsers(Login login)
        {
            return UsersRepsitories.ReadLoginToDB(login);
        }

        public static object ProcessProfile(Profile profile)
        {
            return UsersRepsitories.GetProfileDetails(profile);
        }
        
        public static object ProcessUpdateProfile(UpProfile upProfile)
        {
            return UsersRepsitories.UpdateProfile(upProfile);
        }

        public static object ProcessSignin(Signup signup)
        {
            return UsersRepsitories.GetSignup(signup);
        }

        public static object ProcessAddUsers(AddUser addUser)
        {
            return UsersRepsitories.AddUsers(addUser);
        }

        public static object ProcessGetGroupUser(GroupUser groupUser)
        {
            return UsersRepsitories.GetGroupUser(groupUser);
        }

        public static object ProcessGetGroupUserDetail(GroupUserdetail groupUserdetail)
        {
            return UsersRepsitories.GetGroupUserDetail(groupUserdetail);
        }

        public static object ProcessPostDetails(PostDetails postDetails)
        {
            return UsersRepsitories.GetPostDetails(postDetails);
        }

        public static object ProcessGetPostInfo(Postinfo postinfo)
        {
            return UsersRepsitories.GetPostinfo(postinfo);
        }

        public static object ProcessGetFilters(Filters filters)
        {
            return UsersRepsitories.GetFilters(filters);
        }

        public static object ProcessPostPost(PostPost postPost)
        {
            return UsersRepsitories.InsertPostPost(postPost);
        }

        public static object ProcessPostComment(PostComment postComment)
        {
            return UsersRepsitories.InsertComment(postComment);
        }

        public static object ProcessDeletePost(DeletePost deletePost)
        {
            return UsersRepsitories.DeletePost(deletePost);
        }

        public static object ProcessReportPost(ReportPost reportPost)
        {
            return UsersRepsitories.ReportPost(reportPost);
        }

        public static object ProcessChat(ChatInfo chatInfo)
        {
            return UsersRepsitories.GetChat(chatInfo);
        }

        public static object ProcessChatInfo(Chat chat)
        {
            return UsersRepsitories.GetChatInfo(chat);
        }
        public static object ProcessPostMessage(Message message)
        {
            return UsersRepsitories.Postchat(message);
        }

    }
}