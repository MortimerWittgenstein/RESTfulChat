using Newtonsoft.Json;
using RESTfulChat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulChat.Model
{
    public class ChatList : List<Chat>, ISerializable<ChatList>
    {
        public ChatList Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<ChatList>(value);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
