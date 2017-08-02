using Newtonsoft.Json;
using RESTfulChat.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulChat.Model
{
    public class ChatDictionary : ConcurrentDictionary<int, Chat>, ISerializable<ChatDictionary>
    {
        public ChatDictionary Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<ChatDictionary>(value);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
