using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Files
{
    public class FileService
    {
        public static string? ReadFromFile(string? path, FileMode fileMode)
        {
            using FileStream fileStream = new(path, fileMode);
            using StreamReader streamreader = new(fileStream);

            return streamreader.ReadToEnd();
        }

        public static void WriteToFile(string? json, string? path, FileMode fileMode)
        {
            using FileStream fileStream = new(path, fileMode);
            using StreamWriter streaWriter = new(fileStream);

            streaWriter.Write(json);
        }
        public static void AppendtoFile(string? json, string? path, FileMode fileMode)
        {
            using FileStream fileStream = new(path, fileMode);
            using StreamWriter streaWriter = new(fileStream);
            streaWriter.Write($"{json}\n");
        }
       
    }

}
