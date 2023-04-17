using SOLID.GoodVariration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Classes.Contents
{
    public class MemeContent : IContent, IPublisher//Контент является не только контентом, но и может высылать всем о новых публикаиях
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public static List<ISubscriber> Subscribers { get; set; } = new();//Лист с подписчиками этого контента, дабы разослать подписчикам уведомление

        static MemeContent() => DataBase.IContentType.Add(new MemeContent());


        public void AddContent()
        {
            Console.WriteLine("Введите название новости");
            Name = Console.ReadLine();

            Console.WriteLine("Введите описание новости");
            Description = Console.ReadLine();

        }

        public void Publish(params INotify[] message)//Функция с публикацией контента
        {
            foreach (var subs in Subscribers)
            {
                foreach (var messages in message)
                {
                    messages.SendMessage<string, MemeContent>(subs.Login, this, "Вам пришел новый мем о");
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
