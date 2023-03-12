using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Service.Interfaces
{
    internal interface IAdminService
    {
        public T FromFileToList<T>(string path) where T : class;
        public void FromListToFile<T>(T obj,string path) where T : class;
        public T AddObject<T>(T? obj) where T : class;

    }
}
