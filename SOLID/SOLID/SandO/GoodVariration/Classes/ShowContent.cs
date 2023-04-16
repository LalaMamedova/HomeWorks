using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SandO.GoodVariration.Classes
{
    public class ShowContent
    {
        public  ShowContent(string name)
        {
            for (int i = 0; i < DataBase.IContentType.Count; i++)
            {
                Console.WriteLine($"{i + 1} {DataBase.IContentType[i].GetType().Name}");
            }

            Console.WriteLine(name + " выберите контент для ленты\n0 - Выход");
        }
    }
}
