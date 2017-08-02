using Newtonsoft.Json;
using RESTfulChat.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTfulChat.Model
{
    public class User : ISerializable<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }

        public User Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<User>(value);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
