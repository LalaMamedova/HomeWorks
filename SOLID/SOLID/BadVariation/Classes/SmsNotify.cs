using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.BadVariation.Classes
{
    public class SmsNotify//Не реализован интерфейс, из за чего в будущем будет повтор кода и не будет связки между всеми видами уведомлений
    {
        public News SendNotify(News news,Subscriber subscriber)
        {
            Console.WriteLine($"{subscriber.Login} пришло уведомление о новой новости '{news.Name}'");
            return news;
        }
    }
}
