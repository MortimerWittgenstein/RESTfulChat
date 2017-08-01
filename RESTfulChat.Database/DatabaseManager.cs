using System;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RESTfulChat.Database
{
    public static class DatabaseManager
    {
        public static DataClassesDataContext Db = new DataClassesDataContext();

        public static int InsertUser(string firstName, string lastName, DateTime birthdate, string email, string company)
        {
            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Email = email,
                Company = company
            };

            Db.Users.InsertOnSubmit(user);
            Db.SubmitChanges();
            return user.Id;
        }

        public static int InsertChat(string name)
        {
            var chat = new Chat()
            {
                Name = name
            };

            Db.Chats.InsertOnSubmit(chat);
            Db.SubmitChanges();
            return chat.Id;
        }

        public static void InsertChatUser(int chatId, int userId)
        {
            var chatUser = new ChatUser()
            {
                ChatId = chatId,
                UserId = userId
            };

            Db.ChatUsers.InsertOnSubmit(chatUser);
            Db.SubmitChanges();
        }

        public static void InsertMessage(int chatId, DateTime createdAt, int fromUserId, string text)
        {
            var message = new Message()
            {
                ChatId = chatId,
                CreatedAt = createdAt,
                FromUserId = fromUserId,
                Text = text                
            };

            Db.Messages.InsertOnSubmit(message);
            Db.SubmitChanges();
        }

    }
}
