using RESTfulChat.Model;
using RESTfulChat.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTfulChat.Controllers
{
    //[Authorize]
    public class ChatsController : ApiController
    {
        [HttpGet, Route("api/chats")]
        public ChatDictionary Get() => ChatManager.GetChatList();

        [HttpPost, Route("api/chats")]
        public void Post([FromBody]Chat value) => ChatManager.AddChat(value);

        [HttpGet, Route("api/chats/{id}")]
        public Chat Get(int id) => ChatManager.GetChat(id);

        [HttpPut, Route("api/chats/{id}")]
        public Chat Put(int id,[FromBody]Chat value) => ChatManager.GetChat(id);

        [HttpDelete, Route("api/chats/{id}")]
        public void Delete(int id) => ChatManager.DeleteChat(id);

        [HttpGet,Route("api/chats/{id}/members")]
        public UserDictionary GetMembers(int id) => ChatManager.GetChatMembers(id);

        [HttpPost, Route("api/chats/{id}/members/{uid}")]
        public void PostMember(int id, int uid) => ChatManager.AddMemberToChat(uid, id);

        [HttpGet, Route("api/chats/{id}/members/{uid}")]
        public User GetMember(int id, int uid) => ChatManager.GetChatMember(id, uid);

        [HttpGet, Route("api/chats/{id}/messages")]
        public MessageList GetMessages(int id) => ChatManager.GetMessages(id);

        [HttpPost, Route("api/chats/{id}/messages")]
        public Message PostMessage(int id,[FromBody]Message message) => ChatManager.AddMessageToChat(id,message);
    }
}
