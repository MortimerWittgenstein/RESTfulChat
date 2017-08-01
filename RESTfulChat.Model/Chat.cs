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
        public UserList Members { get; private set; }
        public MessageList Messages { get; private set; }

        public Chat()
        {
            Members = new UserList();
            Messages = new MessageList();
        }

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
