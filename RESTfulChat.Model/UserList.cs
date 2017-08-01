using Newtonsoft.Json;
using RESTfulChat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulChat.Model
{
    public class UserList : List<User>, ISerializable<UserList>
    {
        public UserList Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<UserList>(value);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
