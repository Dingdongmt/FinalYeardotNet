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
        public static bool ProcessUsers(Login login)
        {
            //processing, Validation, Formation
            return UsersRepsitories.ReadLoginToDB(login);
        }

    }
}