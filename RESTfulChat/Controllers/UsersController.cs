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
        [HttpGet, Route("api/users")]
        public UserDictionary Get() => UserManager.GetUserList();

        [HttpPost, Route("api/users")]
        public void Post([FromBody]User value) => UserManager.AddUser(value);

        [HttpGet, Route("api/users/{id}")]
        public User Get(int id) => UserManager.GetUser(id);

        [HttpPut, Route("api/users/{id}")]
        public void Put(int id, [FromBody]User value) => UserManager.ModifyUser(id, value);

        [HttpDelete, Route("api/users/{id}")]
        public void Delete(int id) => UserManager.RemoveUser(id);
    }
}
