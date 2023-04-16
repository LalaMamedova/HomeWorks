using SOLID.BadVariation.Classes;
using SOLID.BadVariation.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.BadVariation.Classes
{
    public class NewsFeed
    {
        public static List<Subscriber> Subscribers = new(); 
        public List<News> newsList = new();
        private News news  = new();
        public void AddNews()
        {
            Console.WriteLine("Введите название новости");
            news.Name = Console.ReadLine();

            Console.WriteLine("Введите описание новости");
            news.Description = Console.ReadLine();

            newsList.Add(news);
            SmsNotify smsNotify = new();//В будущем может появиться другие виды уведомлений, что нагрузит этот класс и этот метод еще сильнее

            foreach (Subscriber subscriber in Subscribers)
            {
                subscriber.MyNews.Add(smsNotify.SendNotify(news, subscriber));//Нарушение S, ибо добавление новости еще и занимается рассылкой всем подписчикам
                                                                  //Хотя это новость может быть например элитной и не должна отправляться всем
            }
        }

       

    }
}
