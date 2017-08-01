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
            ChatManager.Chats = GetChatList();
            UserManager.Users = GetUserList();
        }

        private static Model.UserList GetUserList()
        {
            var users = new Model.UserList();
            var dbUsers = (from u in DatabaseManager.Db.Users select u).ToList();

            foreach (var u in dbUsers)
            {
                users.Add(new Model.User()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Birthdate = (DateTime)u.Birthdate,
                    Email = u.Email,
                    Company = u.Company
                });
            }

            return users;
        }

        private static Model.ChatList GetChatList()
        {
            var chats = new Model.ChatList();
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
                    chat.Members.Add(new Model.User()
                    {
                        Id = dbMember.Id,
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

                chats.Add(chat);
            }

            return chats;
        }
    }
}
