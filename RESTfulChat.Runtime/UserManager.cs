using RESTfulChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTfulChat.Runtime
{
    public static class UserManager
    {
        public static List<User> Users { get; set; }

        public static string GetJSONUserById(int id)
        {
            return GetUserById(id).Serialize();
        }

        public static User GetUserById(int id)
        {
            return Users.Where(u => u.Id.Equals(id)).First();
        }

        public static void AddUser(string firstName, string lastName, DateTime birthdate, string email, string company)
        {
            var user = new User
            {
                Id = Database.DatabaseManager.InsertUser(firstName,lastName,birthdate,email,company),
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Email = email,
                Company = company
            };

            Users.Add(user);
        }
    }
}
