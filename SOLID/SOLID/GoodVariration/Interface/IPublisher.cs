using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Interface
{
    public interface IPublisher
    {
        public void Publish(params INotify[] message);////Функция с публикацией контента, который принимает лист классов, который обладают функцией SendMessage
    }
}
