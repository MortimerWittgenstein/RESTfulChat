using RESTfulChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTfulChat.Runtime
{
    public static class ChatManager
    {
        public static ChatDictionary Chats = new ChatDictionary();

        public static Chat GetChat(int id)
        {
            Chats.TryGetValue(id, out Chat chat);
            return chat;
        }

        public static ChatDictionary GetChatList()
        {
            return Chats;
        }

        public static void ModifyChat(int id, Chat newChat)
        {
            var chat = GetChat(id);
            ModelManager.Update(chat, newChat);
            Database.DatabaseManager.ModifyChat(id, chat.Name, chat.Members, chat.Messages);
        }

        public static void DeleteChat(int id)
        {
            throw new NotImplementedException();
        }

        public static UserDictionary GetChatMembers(int chatId)
        {
            return GetChat(chatId).Members;
        }

        public static User GetChatMember(int chatId, int userId)
        {
            GetChat(chatId).Members.TryGetValue(userId, out User member);
            return member;
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
                throw new Exception("User does not exist");
            }

            var chat = GetChat(chatId);
            if(chat == null)
            {
                throw new Exception("Chat does not exist");
            }

            if (!chat.Members.ContainsKey(user.Id))
            {
                chat.Members.TryAdd(user.Id, user);
                Database.DatabaseManager.InsertChatUser(chatId, userId);
            }
            else
            {
                throw new Exception("User is already member of this chat");
            }
        }

        public static MessageList GetMessages(int chatId)
        {
            return GetChat(chatId).Messages;
        }

        public static Message AddMessageToChat(int chatId, Message message)
        {
            message.Time = DateTime.Now;
            try
            {
                if (message.FromUser.Id != 0 && message.FromUser.UserName == null)
                    throw new Exception("Id or UserName required");

                if (message.FromUser.Id != 0)
                    message.FromUser = UserManager.GetUser(message.FromUser.Id);
                else
                    message.FromUser = UserManager.GetUserByUserName(message.FromUser.UserName);
            }
            catch
            {
                throw new Exception("Message must have a FromUser attribute");
            }

            if(GetChatMember(chatId,message.FromUser.Id) == null)
                throw new Exception("User is not part of ");

            GetChat(chatId).Messages.Add(message);
            Database.DatabaseManager.InsertMessage(chatId, message.Time, message.FromUser.Id, message.Text);
            return message;
        }
    }
}
