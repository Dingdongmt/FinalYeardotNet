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
    public class UpProfile
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public string AddressId { get; set; }
        public string LoginId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
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

    //get add users
    public class AddUser
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string GroupId { get; set; }
    }
    //get group users
    public class GroupUser
    {
        public string GroupId { get; set; }
    }
    //get group users caht info
    public class GroupUserdetail
    {
        public string UserId { get; set; }
    }
    //get group post
    public class PostDetails
    {
        public string GroupId { get; set; }
    }

    //get post info
    public class Postinfo
    {
        public string postinfo { get; set; }
    }

    //get banned words
    public class Filters
    {
        public string filters { get; set; }
    }

    //get post
    public class PostPost
    {
        public string UserId { get; set; }
        public string Container { get; set; }
    }

    //get post
    public class PostComment
    {
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string Container { get; set; }
    }

    //delete post
    public class DeletePost
    {
        public string PCId { get; set; }
        public string PCType { get; set; }
    }

    //Report post
    public class ReportPost
    {
        public string BadWord { get; set; }
    }

    public class ListChat
    {
        public String ChatId { get; set; }
        public String UserId { get; set; }
        public String GroupId { get; set; }
        public String Container { get; set; }
        public String SentTime { get; set; }
    }
    //get banned words
    public class ChatInfo
    {
        public string ChatString { get; set; }
    }
    public class Chat
    {
        public string GroupId { get; set; }
    }

    public class Message
    {
        public string UserId { get; set; }
        public string RecipientId { get; set; }
        public string Container { get; set; }
    }
}