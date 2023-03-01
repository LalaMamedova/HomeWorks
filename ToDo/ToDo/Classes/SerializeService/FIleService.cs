using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Classes.SerializeService
{
    public static class FIleService
    {
        public static string ReadFromFile(string path)
        {
            var res = File.ReadAllText(path);
            if (res.Length > 2)
                return res;
            return null;
        }

        public static void WriteToFile(string path, string json)
        {
            using FileStream fileStream = new(path, FileMode.OpenOrCreate);
            if (fileStream.CanWrite)
            {
                using StreamWriter streamWriter = new(fileStream);
                streamWriter.Write(json);
            }
        }
        public static bool CheckFile(string path)
        {
            using FileStream fileStream = new(path, FileMode.OpenOrCreate);
            if (fileStream.Length > 2)
                return true;
            return false;
        }

        
    }
}
