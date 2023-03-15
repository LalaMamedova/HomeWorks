using AdminPanel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Service.Classes
{
    public class IDService
    {
        public static void SerializeID(int id, string path)
        {
            var json = Serialize.SerializeLibary.Serialize<int>(id);
            Serialize.FileService.Write(json, path);
        }
        public static string DesirializeID(string path)
        {
            var json = Serialize.FileService.Read(path);
            return Serialize.SerializeLibary.Deserialize<string>(json);
        }
    }
}
