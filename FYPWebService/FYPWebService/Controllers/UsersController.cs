using FYPWebService.Models;
using FYPWebService.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FYPWebService.Controllers
{
    public class LoginController : ApiController
    {
        //get login informations
        [HttpPost]
        [Route("Login")]
        [EnableCors(origins:"*",headers:"*",methods:"*")]
        public object Login(Login login)
        {
            if (login == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessUsers(login);
        }

        //get profile details
        [HttpPost]
        [Route("Profile")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object Profile(Profile profile)
        {
            if (profile == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessProfile(profile);
        }

        //get profile details
        [HttpPost]
        [Route("UpdateProfile")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object UpProfile(UpProfile upProfile)
        {
            if (upProfile.UserId == null && upProfile.GroupId == null && upProfile.AddressId == null && upProfile.LoginId == null && upProfile.Name == null && upProfile.UserName == null && upProfile.Password == null && upProfile.GroupName == null && upProfile.Address1 == null && upProfile.County == null && upProfile.Country == null && upProfile.PostCode == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessUpdateProfile(upProfile);
        }

        //get signup details
        [HttpPost]
        [Route("Signup")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object Signup(Signup signup)
        {
            if (signup.Name == null && signup.UserName == null && signup.Password == null && signup.GroupName == null && signup.Address1 == null && signup.County == null && signup.Country == null && signup.PostCode == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessSignin(signup);
        }

        //get signup details
        [HttpPost]
        [Route("AddUser")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object AddUser(AddUser addUser)
        {
            if (addUser.Name == null && addUser.UserName == null && addUser.Password == null && addUser.GroupId == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessAddUsers(addUser);
        }

        //get Group Users
        [HttpPost]
        [Route("GroupUsers")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object GroupUser(GroupUser groupUser)
        {
            if (groupUser == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessGetGroupUser(groupUser);
        }

        //get Group user detail
        [HttpPost]
        [Route("GroupUserDetail")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object groupUserdetail(GroupUserdetail groupUserdetail)
        {
            if (groupUserdetail == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessGetGroupUserDetail(groupUserdetail);
        }

        //get Post Details
        [HttpPost]
        [Route("PostDetails")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object PostDetails(PostDetails postDetails)
        {
            if (postDetails == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessPostDetails(postDetails);
        }

        //get filtered words
        [HttpGet]
        [Route("GetPostInfo")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object GetPostinfo(Postinfo postinfo)
        {
            return LoginProcessor.ProcessGetPostInfo(postinfo);
        }

        //get filtered words
        [HttpGet]
        [Route("GetFilters")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object GetFilters(Filters filters)
        {
            return LoginProcessor.ProcessGetFilters(filters);
        }

        //Post Post
        [HttpPost]
        [Route("PostPost")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object PostPost(PostPost postPost)
        {
            if (postPost.UserId == null && postPost.Container == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessPostPost(postPost);
        }

        //Comment on a Post
        [HttpPost]
        [Route("PostComment")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object PostComment(PostComment postComment)
        {
            if (postComment.UserId == null && postComment.Container == null && postComment.PostId == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessPostComment(postComment);
        }

        //Delete Post
        [HttpPost]
        [Route("DeletePost")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object DeletePost(DeletePost deletePost)
        {
            if (deletePost == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessDeletePost(deletePost);
        }

        //Delete Post
        [HttpPost]
        [Route("ReportPost")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object ReportPost(ReportPost reportPost)
        {
            if (reportPost == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessReportPost(reportPost);
        }

        
        //get chat Details
        [HttpPost]
        [Route("ChatInfo")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object GetChatInfo(Chat chat)
        {
            if (chat == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessChatInfo(chat);
        }

        //get Chat info
        [HttpGet]
        [Route("GetChat")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object GetChatInfo(ChatInfo chatInfo)
        {
            return LoginProcessor.ProcessChat(chatInfo);
        }

        //Post Message
        [HttpPost]
        [Route("Message")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object GetMessage(Message message)
        {
            if (message.UserId == null && message.RecipientId == null && message.Container == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessPostMessage(message);
        }
    }
}
