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
            using FileStream fileStream = new(path, FileMode.Open);
            if (fileStream.CanRead)
            {
                using StreamReader streamReader = new StreamReader(fileStream);
                return streamReader.ReadToEnd();
            }
            return null;
        }

        public static void WriteToFile(string path, string json)
        {
            using FileStream fileStream = new(path, FileMode.OpenOrCreate);
            if (fileStream.CanWrite)
            {
                using StreamWriter streamWriter = new(fileStream);
                streamWriter.WriteLine(json);
            }
            
        }

        public static void ReWrite(string path,string? json)
        {
            FileStream Truncate = new(path, FileMode.Truncate);
            Truncate.Close();

            using FileStream fileStream = new(path, FileMode.OpenOrCreate);
            if (fileStream.CanWrite)
            {
                using StreamWriter streamWriter = new(fileStream);
                streamWriter.WriteLine(json);
            }
        }
    }
}
