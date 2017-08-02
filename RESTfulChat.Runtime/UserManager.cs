using RESTfulChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTfulChat.Runtime
{
    public static class UserManager
    {
        public static UserList Users = new UserList();

        public static string GetJSONUser(int id)
        {
            return GetUser(id).Serialize();
        }

        public static User GetUser(int id)
        {
            return Users.Where(u => u.Id.Equals(id)).First();
        }

        public static string GetJSONUserList()
        {
            return Users.Serialize();
        }

        public static UserList GetUserList()
        {
            return Users;
        }

        public static int AddJSONUser(string json)
        {
            return AddUser(new User().Deserialize(json));
        }

        public static int AddUser(User user)
        {
            user.Id = Database.DatabaseManager.InsertUser(user.UserName, user.FirstName, user.LastName, user.Birthdate, user.Email, user.Company);
            Users.Add(user);
            return user.Id;
        }
    }
}
