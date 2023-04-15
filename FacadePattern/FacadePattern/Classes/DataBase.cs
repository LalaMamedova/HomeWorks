using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes
{
    public class DataBase
    {
        public static List<Good> goods = new()
        {
            new Good("Футболка",5000,52),
            new Good("Штаны",4014, 48),
            new Good("Майки",540,17),
            new Good("Кофты",1240,35),

        };

       
    }
}
