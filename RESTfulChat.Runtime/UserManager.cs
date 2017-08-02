using RESTfulChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTfulChat.Runtime
{
    public static class UserManager
    {
        public static UserDictionary Users = new UserDictionary();

        public static string GetJSONUser(int id)
        {
            return GetUser(id).Serialize();
        }

        public static User GetUser(int id)
        {
            Thread.Sleep(5000);
            Users.TryGetValue(id, out User user);
            return user;
        }
        
        public static string GetJSONUserList()
        {
            return Users.Serialize();
        }

        public static UserDictionary GetUserList()
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
            Users.TryAdd(user.Id, user);
            return user.Id;
        }

        public static void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
