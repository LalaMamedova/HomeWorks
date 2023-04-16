using SOLID.SandO.GoodVariration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SandO.GoodVariration.Classes
{
    public class DataBase
    {
        public static List<IContent> IContentType { get; set; } = new List<IContent>();
        public static List<ISubscriber> Subscribers { get; set; } = new();

        
    }
}
