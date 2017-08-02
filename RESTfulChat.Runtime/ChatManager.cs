using RESTfulChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTfulChat.Runtime
{
    public static class ChatManager
    {
        public static ChatDictionary Chats = new ChatDictionary();

        public static string GetJSONChat(int id)
        {
            return GetChat(id).Serialize();
        }

        public static Chat GetChat(int id)
        {
            Chats.TryGetValue(id, out Chat chat);

            return chat;
        }

        public static string GetJSONChatMembers(int chatId)
        {
            return GetChatMembers(chatId).Serialize(); 
        }

        public static UserDictionary GetChatMembers(int chatId)
        {
            return GetChat(chatId).Members;
        }

        public static int AddJSONChat(string json)
        {
            return AddChat(new Chat().Deserialize(json));
        }

        public static int AddChat(Chat chat)
        {
            chat.Id = Database.DatabaseManager.InsertChat(chat.Name);
            Chats.TryAdd(chat.Id, chat);
            return chat.Id;
        }

        public static void AddMemberToChat(int userId, int chatId)
        {
            var user = UserManager.GetUser(userId);
            if(user == null)
            {
                System.Console.WriteLine("User does not exist");
                return;
            }

            var chat = GetChat(chatId);
            if(chat == null)
            {
                System.Console.WriteLine("Chat does not exist");
                return;
            }

            if (!chat.Members.ContainsKey(user.Id))
            {
                chat.Members.TryAdd(user.Id, user);
                Database.DatabaseManager.InsertChatUser(chatId, userId);
            }
            else
            {
                System.Console.WriteLine("User is already Member of this chat");
                return;
            }
        }

        public static void AddMessageToChat(int chatId, string json)
        {
            var message = new Message().Deserialize(json);
            message.Time = DateTime.Now;
            GetChat(chatId).Messages.Add(message);
            Database.DatabaseManager.InsertMessage(chatId, message.Time, message.FromUser.Id, message.Text);
        }
    }
}
