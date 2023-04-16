using SOLID.GoodVariration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Classes
{
    public class DataBase
    {
        public static List<IContent> IContentType { get; set; } = new();//Статический список со всеми контентами дабы все пользователи видели все контенты
        public static List<INotify> NotifiyesType { get; set; } = new();
    }
}
