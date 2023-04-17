using Microsoft.VisualBasic;
using SOLID.GoodVariration.Classes.Contents;
using SOLID.GoodVariration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Classes
{
    internal class UsualUser : ISubscriber//Обычный пользователь, пока что является лишь подписчиком, но в будущем может быть кем еще кем угодно
    {
        public List<IContent> Contents { get; set; } = new();//Список с лентой контента. //Соблюден LSP, ибо если заменю IContent на классы то ничего не изменится
        public string Login { get; set; }
        public UsualUser(string login) { Login = login; }
        private int choice = 1;

        public void Subscribe()//Выбор для подписки на контент. Еще хотела скинуть это в конструктор, ибо пользоватялю по дефолту в начале должны дать выбор куда подписаться
        {
            ShowContent.ShowAllContent(Login);
            choice = Int32.Parse(Console.ReadLine());

            if (choice > 0)
            {
                Contents.Add(DataBase.IContentType[choice - 1]);
                SubscribeTo(DataBase.IContentType[choice - 1]);
            }
        }
       

        public void Unsubscribe()//Функция для отписки. В данном случаи показывается уже свой, а не общий контент
        {
            for (int i = 0; i < Contents.Count; i++)
                Console.WriteLine($"{i + 1} {Contents[i].GetType().Name}");

            choice = Int32.Parse(Console.ReadLine());
            Contents.Remove(DataBase.IContentType[choice-1]);
        }

        public void SubscribeTo(IContent content)//Функция чтобы пользователь смог добавиться в список из подписчиков того контента куда он подписался
        {
            switch (content)
            {
                case NewsContent:
                    NewsContent.Subscribers.Add(this);
                    break;

                case MemeContent:
                    MemeContent.Subscribers.Add(this);
                    break;
            }
        }

    }
}
