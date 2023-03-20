using Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Service.Classes
{
    internal class IDService
    {
        public static void SerializeID(int id, string path)
        {
            var json = Serialize.SerializeLibary.Serialize<int>(id);
            FileService.Truncate("CustomersID.json");
            Serialize.FileService.Write(json, path);
        }
        public static int DesirializeID(string path)
        {
            var json = Serialize.FileService.Read(path);
            if (Serialize.SerializeLibary.Deserialize<string>(json) == null)
                return 0;
           return Int32.Parse(Serialize.SerializeLibary.Deserialize<string>(json));
        }
    }
}
