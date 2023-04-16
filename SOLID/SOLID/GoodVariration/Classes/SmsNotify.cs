using SOLID.GoodVariration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Classes
{
    internal class SmsNotify : INotify//Функция отправляющая уведомление на SMS
    {
        public void SendMessage<T, T2>(T who, T2 what, string message )
        {
            Console.WriteLine($"{who} {message} {what} на SMS");
        }

      
    }
}
