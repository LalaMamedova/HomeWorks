﻿using SOLID.GoodVariration.Classes;
using SOLID.GoodVariration.Interface;
using SOLID.BadVariation.Classes;
using SOLID.BadVariation.Classes;

Console.WriteLine("\n1.Плохой вариант" +
                  "\n2.Хороший варинат" +
                  "\n0.Выйти");
int choice;
bool choiceRes = Int32.TryParse(Console.ReadLine(), out choice);

if (choiceRes)
{
    switch (choice)
    {
        case 1:
            {
                Subscriber subscriber = new("Лала");
                Subscriber subscriber2 = new("Ляман");

                NewsFeed feed = new NewsFeed();
                feed.AddNews();

                break;
            }

            case 2:
            {
                IContent content = new NewsContent();
                content = new MemeContent();

                ISubscriber usualUser = new UsualUser("Лала");
                usualUser.Subscribe();

                content.AddContent();

                ((MemeContent)content).Publish(new EmailNotify(), new SOLID.GoodVariration.Classes.SmsNotify());

               
                break;
            }
    }

}


