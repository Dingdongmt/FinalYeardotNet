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

        public static object ProcessSignin(Signup signup)
        {
            return UsersRepsitories.GetSignup(signup);
        }

        public static object ProcessGetGroupUser(GroupUser groupUser)
        {
            return UsersRepsitories.GetGroupUser(groupUser);
        }

    }
}