using RESTfulChat.Model;
using System.Collections.Generic;
using System.Linq;

namespace RESTfulChat.Runtime
{
    public static class ChatManager
    {
        private static List<Chat> Chats { get; set; }

        public static string GetChatById(int id)
        {
            return Chats.Where(c => c.Id.Equals(id)).First().Serialize();
        }
    }
}
