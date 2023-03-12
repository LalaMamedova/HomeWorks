using Newtonsoft.Json;

namespace Serialize
{
    public static class SerializeLibary
    {
        public static string? Serialize<T>(T? obj)
        {
            if (obj == null) return null;

            return JsonConvert.SerializeObject(obj);
        }

        public static T? Deserialize<T>(string? json) where T : class
        {
            if (json == null) return null;

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}