using System;
using Newtonsoft.Json;
using RESTfulChat.Core;

namespace RESTfulChat.Model
{
    public class Message : ISerializable<Message>
    {
        public DateTime Time { get; set; }
        public User FromUser { get; set; }
        public string Text { get; set; }

        public Message Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<Message>(value);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
