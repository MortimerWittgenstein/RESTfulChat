using System;
using System.Collections.Generic;
using System.Text;

namespace RESTfulChat.Core
{
    public interface ISerializable<T>
    {
        string Serialize();
        T Deserialize(string value);
    }
}
