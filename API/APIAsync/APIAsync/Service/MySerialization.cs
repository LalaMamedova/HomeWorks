using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIAsync.Service
{
    public class MySerialization
    {
        public static void Serialization<T>(T obj)
        {
            if (obj == null) throw new ArgumentNullException("Ничего нет");
            else
                JsonConvert.SerializeObject(obj);
        }

        public static T? Desirialize<T>(string? json)
        {
            if (string.IsNullOrEmpty(json)) throw new ArgumentNullException("Ничего нет");
            else
                return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
