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

        //get Post Details
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
    }
}
