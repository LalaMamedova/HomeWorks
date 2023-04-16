using SOLID.BadVariation.Classes;
using SOLID.GoodVariration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Classes
{
    public class NewsContent:IContent,IPublisher
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public static List<ISubscriber> Subscribers { get; set; } = new();

        static NewsContent()
        {
            DataBase.IContentType.Add(new NewsContent());
        }
        
        public void AddContent() 
        {
            Console.WriteLine("Введите название новости");
            Name = Console.ReadLine();

            Console.WriteLine("Введите описание новости");
            Description = Console.ReadLine();
        }

        public void Publish(params INotify[] message)
        {
            foreach (var subs in Subscribers)
            {
                foreach (var messages in message)
                {
                    messages.SendMessage<string, NewsContent>(subs.Login, this, "Вам пришла новая новость о");
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
