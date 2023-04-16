using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SandO.GoodVariration.Interface
{
    public interface INotify//Интферфейс для отправки сообщений
    {
        public void SendMessage<T,T2>(T who, T2 what,string message = "Вам пришло новое уведомление о");
       
    }
}
