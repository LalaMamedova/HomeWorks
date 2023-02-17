using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPersons.Service.Clases
{
    internal static class Files
    {
        public static void WriteToFile(string? path, string? json)
        {
            if (path != null && json != null)
            {
                using FileStream fileStream = new(path, FileMode.OpenOrCreate);
                using StreamWriter streaWriter = new(fileStream);
                streaWriter.Write(json);
            }
            else
                throw new ArgumentNullException("Ошибка с файлом");
        }
       
        public static string ReadFromFile(string path)
        {
            using FileStream filestream = new(path, FileMode.OpenOrCreate);
            using StreamReader sr = new StreamReader(filestream);
            return sr.ReadToEnd();
        }
    }
}
