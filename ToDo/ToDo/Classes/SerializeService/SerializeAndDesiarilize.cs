using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDo.Classes.SerializeService
{
    public static class SerializeAndDesiarilize
    {
        public static string SerializeObject<T>(T? anyObject)where T : class
        {
            return JsonConvert.SerializeObject(anyObject);
        }
        public static T DesializeObject<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
