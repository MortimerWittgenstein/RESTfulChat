using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulChat.Runtime
{
    public static class ModelManager
    {
        public static void Update<T>(T toUpdate, T updateObject) where T : class
        {
            foreach (var prop in updateObject.GetType().GetProperties())
            {
                if (!prop.CanRead)
                    continue;

                var newValue = prop.GetValue(updateObject);
                var oldValue = prop.GetValue(toUpdate);

                if (oldValue == newValue || newValue == null || IsDefault(newValue))
                    continue;

                if (!prop.CanWrite)
                    continue;


                prop.SetValue(toUpdate, newValue);
            }
        }

        public static bool IsDefault<T>(T obj)  => obj.GetType().IsValueType ? obj.Equals(Activator.CreateInstance(obj.GetType())) : false;
        
    }
}
