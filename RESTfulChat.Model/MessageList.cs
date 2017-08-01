using Newtonsoft.Json;
using RESTfulChat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulChat.Model
{
    public class MessageList : List<Message>, ISerializable<MessageList>
    {
        public MessageList Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<MessageList>(value);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
