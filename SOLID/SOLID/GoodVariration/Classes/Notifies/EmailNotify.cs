using SOLID.GoodVariration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Classes.Notifies
{
    public class EmailNotify : INotify
    {
        static EmailNotify()
        {
            DataBase.NotifiyesType.Add(new EmailNotify());
        }
        public void SendMessage<T, T2>(T who, T2 what, string message)
        {
            Console.WriteLine($"{who} {message} {what} на Email");
        }


    }
}
