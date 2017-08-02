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
        public UserDictionary Get()
        {
            return UserManager.GetUserList();
        }

        // GET api/users/5
        [HttpGet]
        public User Get(int id) => UserManager.GetUser(id);

        [HttpPost]
        public void Post([FromBody]User value) => UserManager.AddUser(value);

        // DELETE api/users/5
        [HttpDelete]
        public void Delete(int id) => UserManager.RemoveUser(id);
    }
}
