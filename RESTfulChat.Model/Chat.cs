using System;
using System.Collections.Generic;
using RESTfulChat.Core;
using Newtonsoft.Json;

namespace RESTfulChat.Model
{
    public class Chat : ISerializable<Chat>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }
        public List<Message> Messages { get; set; }

        public Chat Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<Chat>(value);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
