using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTfulChat.Runtime;
using RESTfulChat.Model;

namespace RESTfulChat.Controllers
{
    //[Authorize]
    public class UsersController : ApiController
    {
        // GET api/users
        [HttpGet]
        public UserList Get()
        {
            return UserManager.GetUserList();
        }

        // GET api/users/5
        [HttpGet]
        public User Get(int id)
        {
            return UserManager.GetUser(id);
        }

        [HttpPost]
        public void Post([FromBody]User value)
        {
            UserManager.AddUser(value);
        }
    }
}
