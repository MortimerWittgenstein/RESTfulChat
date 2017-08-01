using RESTfulChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTfulChat.Runtime
{
    public static class ChatManager
    {
        private static List<Chat> Chats { get; set; }

        public static string GetJSONChatById(int id)
        {
            return GetChatById(id).Serialize();
        }

        public static Chat GetChatById(int id)
        {
            return Chats.Where(c => c.Id.Equals(id)).First();
        }

        public static int AddChat(string name)
        {
            var chat = new Chat()
            {
                Id = Database.DatabaseManager.InsertChat(name),
                Name = name
            };

            Chats.Add(chat);
            return chat.Id;
        }

        public static void AddMemberToChat(int userId, int chatId)
        {
            var user = UserManager.GetUserById(userId);
            if(user == null)
            {
                System.Console.WriteLine("User does not exist");
                return;
            }    

            var chat = GetChatById(chatId);
            if(chat == null)
            {
                System.Console.WriteLine("Chat does not exist");
                return;
            }

            if (chat.Members.Where(m => m.Id.Equals(userId)).First() == null)
            {
                chat.Members.Add(user);
                Database.DatabaseManager.InsertChatUser(chatId, userId);
            }
            else
            {
                System.Console.WriteLine("User is already Member of this chat");
                return;
            }
        }

        public static void AddMessageToChat(int chatId, int userId, string text)
        {
            var fromUser = UserManager.GetUserById(userId);
            var message = new Message
            {
                FromUser = fromUser,
                Text = text,
                Time = DateTime.Now
            };

            var chat = GetChatById(chatId);

            chat.Messages.Add(message);
            Database.DatabaseManager.InsertMessage(chatId, message.Time, userId, text);
        }
    }
}
