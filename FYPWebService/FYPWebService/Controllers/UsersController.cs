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

        //get signup details
        [HttpPost]
        [Route("Signup")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public object Signup(Signup signup)
        {
            if (signup == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessSignin(signup);
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
            if (postPost == null)
            {
                return "false";
            }
            return LoginProcessor.ProcessPostPost(postPost);
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

        
        //get Post Details
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
    }
}
