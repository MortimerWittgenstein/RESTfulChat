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

        public static User GetUser(int id)
        {
            Users.TryGetValue(id, out User user);
            return user;
        }

        internal static User GetUserByUserName(string userName)
        {
            var user = (from u in Users
                        where u.Value.UserName == userName
                        select u).ToList().First().Value;
            return user;
        }

        public static UserDictionary GetUserList()
        {
            return Users;
        }

        public static int AddUser(User user)
        {
            user.Id = Database.DatabaseManager.InsertUser(user.UserName, user.FirstName, user.LastName, user.Birthdate, user.Email, user.Company);
            Users.TryAdd(user.Id, user);
            return user.Id;
        }

        public static void ModifyUser(int id, User newUser)
        {
            var user = GetUser(id);
            ModelManager.Update(user,newUser);
            Database.DatabaseManager.ModifyUser(id, user.UserName, user.FirstName, user.LastName, user.Birthdate, user.Email, user.Company);
        }

        public static void RemoveUser(int id)
        {
            var deletedUser = new User();
            Users.TryRemove(id, out deletedUser);
            Database.DatabaseManager.DeleteUser(id);
        }
    }
}
