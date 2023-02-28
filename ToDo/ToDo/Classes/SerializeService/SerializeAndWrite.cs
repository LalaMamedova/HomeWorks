using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Classes;

namespace ToDo.Classes.SerializeService
{
    public static class SerializeAndWrite
    {
        public static T ReadAndDesiarile<T>(string path) where T : class
        {
            var json = FIleService.ReadFromFile(path);
            return SerializeAndDesiarilize.DesializeObject<T>(json);
        }

        public static void WriteAndSerialize<T>(string? path, T anyObj) where T:class
        {
            var json = SerializeAndDesiarilize.SerializeObject<T>(anyObj);
            FIleService.WriteToFile(path,json);
        }
    }
}
