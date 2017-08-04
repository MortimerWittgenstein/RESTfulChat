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

        public static int InsertUser(string userName, string firstName, string lastName, DateTime birthdate, string email, string company)
        {
            var db = new DataClassesDataContext();
            var dbUser = new User()
            {
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Email = email,
                Company = company
            };

            db.Users.InsertOnSubmit(dbUser);
            db.SubmitChanges();
            return dbUser.Id;
        }

        public static void ModifyChat(int chatId, string name, Model.UserDictionary members, Model.MessageList messages)
        {
            var db = new DataClassesDataContext();
            var dbChat = (from c in db.Chats
                          where c.Id == chatId
                          select c).ToList().First();
            dbChat.Name = name;

            throw new NotImplementedException();
        }

        public static void ModifyUser(int userId, string userName, string firstName, string lastName, DateTime birthdate, string email, string company)
        {
            var db = new DataClassesDataContext();
            var dbUser = (from u in db.Users
                          where u.Id == userId
                          select u).ToList().First();

            dbUser.UserName = userName;
            dbUser.FirstName = firstName;
            dbUser.LastName = lastName;
            dbUser.Birthdate = birthdate;
            dbUser.Email = email;
            dbUser.Company = company;

            db.SubmitChanges();
        }

        public static void DeleteUser(int userId)
        {
            var db = new DataClassesDataContext();
            var dbUser = (from u in db.Users
                          where u.Id == userId
                          select u).ToList().First();
            db.Users.DeleteOnSubmit(dbUser);
            db.SubmitChanges();
        }

        public static int InsertChat(string name)
        {
            var db = new DataClassesDataContext();
            var chat = new Chat()
            {
                Name = name
            };

            db.Chats.InsertOnSubmit(chat);
            db.SubmitChanges();
            return chat.Id;
        }

        public static void InsertChatUser(int chatId, int userId)
        {
            var db = new DataClassesDataContext();
            var dbChatUser = new ChatUser()
            {
                ChatId = chatId,
                UserId = userId
            };

            db.ChatUsers.InsertOnSubmit(dbChatUser);
            db.SubmitChanges();
        }

        public static void InsertMessage(int chatId, DateTime createdAt, int fromUserId, string text)
        {
            var db = new DataClassesDataContext();
            var dbMessage = new Message()
            {
                ChatId = chatId,
                CreatedAt = createdAt,
                FromUserId = fromUserId,
                Text = text                
            };

            db.Messages.InsertOnSubmit(dbMessage);
            db.SubmitChanges();
        }



    }
}
