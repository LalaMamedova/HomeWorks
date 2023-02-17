using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPersons.Service.Clases
{
    internal static class SerializeConvert
    {

        public static string? Serialize<T>(T? obj)
        {
            if (obj == null)
                throw new ArgumentNullException($"{nameof(obj)} пустой!");

            return JsonConvert.SerializeObject(obj);
        }
        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);
        
    }
}
