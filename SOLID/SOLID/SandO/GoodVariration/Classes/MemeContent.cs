using SOLID.SandO.GoodVariration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SandO.GoodVariration.Classes
{
    internal class MemeContent : IContent,IPublisher//Контент является не только контентом, но и может высылать всем о новых публикаиях
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public static List<ISubscriber> Subscribers { get; set; } = new();

        static MemeContent()
        {
            DataBase.IContentType.Add(new MemeContent());

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
                    messages.SendMessage<string, MemeContent>(subs.Login, this);
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
