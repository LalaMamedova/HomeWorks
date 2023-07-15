using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitCrud.Models.Class
{
    public class MyColors
    {
        public static List<string> ColorsList { get; set; } = new()
        {
            "Красный", "Белый", "Синий","Голубой",
            "Розовый","Серый","Желтый","Фиолетовые",
        };

    }
}
