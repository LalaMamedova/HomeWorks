using AdminPanel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialize;

namespace AdminPanel.Service.Classes
{
    internal class AdminService : IAdminService
    {

        public T AddObject<T>(T? obj) where T : class
        {
            if(obj == null) 
                throw new ArgumentNullException($"{nameof(obj)} является пустым, пожалуйста, введите данные");
            return obj;
        }

        public T FromFileToList<T>(string path) where T : class
        {
            string? json = Serialize.FileService.Read(path);
            if (string.IsNullOrEmpty(json)) return null;  else return Serialize.SerializeLibary.Deserialize<T>(json);

        }

        public void FromListToFile<T>(T obj, string path) where T : class
        {
            var json = Serialize.SerializeLibary.Serialize<T>(obj);
            Serialize.FileService.Write(json,path);
        }
    }
}
