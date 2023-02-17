using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Files
{
    public class SerializeService
    {
        public static JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public static string Serialize<T>(List<T> obj) where T : MySerializable
        { 
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static List<MySerializable> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<List<MySerializable>>(json, settings);
        }

        
    }
}
