using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYPWebService.Models
{
    //get login details
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    //get username form Frontend
    public class Profile
    {
        public string UserId { get; set; }
    }

    //get signup details Frontend
    public class Signup
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string GroupName { get; set; }
        public string GroupBio { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
    }
    //get group users
    public class GroupUser
    {
        public string GroupId { get; set; }
    }
    //get group users
    public class PostDetails
    {
        public string GroupId { get; set; }
    }
    //get post
    public class PostPost
    {
        public string UserId { get; set; }
        public string Container { get; set; }
    }

    public class Chat
    {
        public string UserId { get; set; }
    }
}