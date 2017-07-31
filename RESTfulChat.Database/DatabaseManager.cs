using System;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;

namespace RESTfulChat.Database
{
    public static class DatabaseManager
    {
        public static DataClassesDataContext Connection = new DataClassesDataContext();

        public static void InsertUser(string firstName, string lastName, DateTime birthdate, string email, string company)
        {
            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Email = email,
                Company = company
            };

            Connection.Users.InsertOnSubmit(user);
            Connection.SubmitChanges();
        }

        public static void InsertChat(string name)
        {
            var chat = new Chat()
            {
                Name = name
            };

            Connection.Chats.InsertOnSubmit(chat);
            Connection.SubmitChanges();
        }

        public static void InsertChatUser(int chatId, int userId)
        {
            var chatUser = new ChatUser()
            {
                ChatId = chatId,
                UserId = userId
            };

            Connection.ChatUsers.InsertOnSubmit(chatUser);
            Connection.SubmitChanges();
        }

        public static void InsertMessage(int chatId, int fromUserId, string text)
        {
            var message = new Message()
            {
                ChatId = chatId,
                CreatedAt = DateTime.Now,
                FromUserId = fromUserId,
                Text = text                
            };

            Connection.Messages.InsertOnSubmit(message);
            Connection.SubmitChanges();
        }

    }
}
