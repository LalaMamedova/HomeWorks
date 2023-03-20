using AdminPanel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanel.Model;
using System.Collections.ObjectModel;

namespace AdminPanel.Service.Interfaces
{
    public interface IAdminService
    {
        public T AddObject<T>(T? obj) where T : class;
        public T FromFileToList<T>(string path) where T : class;
        public void FromListToFile<T>(T obj,string path) where T : class;
        public bool CkeckCategoryExist(Category category);
        

    }
}
