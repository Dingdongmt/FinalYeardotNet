using FYPWebService.Models;
using FYPWebService.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FYPWebService.Controllers
{
    public class LoginController : ApiController
    {

        [HttpPost]
        [Route("Login")]
        // POST api/values
        public bool SaveUser(Login login)
        {
            if (login == null)
            {
                return false;
            }
            return LoginProcessor.ProcessUsers(login);
        }

    }
}
