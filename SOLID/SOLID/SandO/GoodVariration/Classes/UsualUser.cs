using Microsoft.VisualBasic;
using SOLID.SandO.GoodVariration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SandO.GoodVariration.Classes
{
    internal class UsualUser : ISubscriber
    {
        public List<IContent> contents { get; set; } = new();
        public UsualUser(string login) { Login = login; }
        public string Login { get; set; }


        public void Subscribe()
        {
            int choice = 1;

            while (choice != 0)
            {
                ShowContent showContent = new ShowContent(Login);
                choice = Int32.Parse(Console.ReadLine());

                if (choice > 0)
                {
                    contents.Add(DataBase.IContentType[choice - 1]);
                    SubscribeTo(DataBase.IContentType[choice - 1]);
                }
                Console.Clear();

            }
        }

        public void SubscribeTo(IContent content)
        {
            switch (content)
            {
                case  NewsContent:
                    NewsContent.Subscribers.Add(this);
                    break;

                case MemeContent:
                    MemeContent.Subscribers.Add(this);
                    break;
            }
        }

        public void Unsubscribe()
        {
            for (int i = 0; i < contents.Count; i++)
                Console.WriteLine($"{i + 1} {contents[i].GetType().Name}");
            
            int choice = 1;

            while (choice != 0)
            {
                choice = Int32.Parse(Console.ReadLine()); choice--;
                contents.Remove(DataBase.IContentType[choice]);
                Console.Clear();

            }
        }

        

        
    }
}
