using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Classes
{
    public class ShowContent//Дополнительный(костыльный) класс дабы я не повторяла данный участок
    {
       
        public static void ShowAllContent(string name)
        {
            Console.WriteLine(name + " выберите контент для ленты\n0 - Выход");
            for (int i = 0; i < DataBase.IContentType.Count; i++)
            {
                Console.WriteLine($"{i + 1} {DataBase.IContentType[i].GetType().Name}");
            }

        }

       
    }
}
