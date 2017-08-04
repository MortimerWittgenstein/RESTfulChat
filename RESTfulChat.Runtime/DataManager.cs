using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTfulChat.Database;

namespace RESTfulChat.Runtime
{
    public static class DataManager
    {
        public static void LoadDataFromDB()
        {
            UserManager.Users = GetUserList();
            ChatManager.Chats = GetChatList();
        }

        private static Model.UserDictionary GetUserList()
        {
            var users = new Model.UserDictionary();
            var dbUsers = (from u in DatabaseManager.Db.Users select u).ToList();

            foreach (var dbUser in dbUsers)
            {
                users.TryAdd(dbUser.Id, new Model.User()
                {
                    Id = dbUser.Id,
                    UserName = dbUser.UserName,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Birthdate = (DateTime)dbUser.Birthdate,
                    Email = dbUser.Email,
                    Company = dbUser.Company
                });
            }

            return users;
        }

        private static Model.ChatDictionary GetChatList()
        {
            var chats = new Model.ChatDictionary();
            var dbChats = (from c in DatabaseManager.Db.Chats select c).ToList();

            foreach (var dbChat in dbChats)
            {
                var chat = new Model.Chat()
                {
                    Id = dbChat.Id,
                    Name = dbChat.Name
                };

                // add members
                var dbMembers = (from m in DatabaseManager.Db.Users
                                 join cu in DatabaseManager.Db.ChatUsers on m.Id equals cu.UserId
                                 where cu.ChatId == dbChat.Id
                                 select m).ToList();

                foreach (var dbMember in dbMembers)
                {
                    chat.Members.TryAdd(dbMember.Id, new Model.User()
                    {
                        Id = dbMember.Id,
                        UserName = dbMember.UserName,
                        FirstName = dbMember.FirstName,
                        LastName = dbMember.LastName,
                        Birthdate = (DateTime)dbMember.Birthdate,
                        Email = dbMember.Email,
                        Company = dbMember.Company
                    });
                }

                // add messages
                var dbMessages = (from m in DatabaseManager.Db.Messages
                                  join c in DatabaseManager.Db.Chats on m.ChatId equals c.Id
                                  where c.Id == dbChat.Id
                                  select m).ToList();

                foreach (var dbMessage in dbMessages)
                {
                    chat.Messages.Add(new Model.Message()
                    {
                        FromUser = UserManager.GetUser(dbMessage.FromUserId),
                        Time = dbMessage.CreatedAt,
                        Text = dbMessage.Text       
                    });
                    
                }

                chats.TryAdd(chat.Id, chat);
            }

            return chats;
        }
    }
}
