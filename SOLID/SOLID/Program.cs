using SOLID.SandO.BadVariation.Classes;
using SOLID.SandO.GoodVariration.Classes;
using SOLID.SandO.GoodVariration.Interface;
//Console.WriteLine("\n1.S и O" +
//                  "\n2.L" +
//                  "\n3.I" +
//                  "\n4.D" +
//                  "\n5.S и O"+
//                  "\n0.Выйти");
//int choice;
//bool choiceRes = Int32.TryParse(Console.ReadLine(), out choice);

//if (choiceRes)
//{
//    int choice2;
//    bool choiceRes2 = Int32.TryParse(Console.ReadLine(), out choice2);
//}

IContent content = new NewsContent();
content = new MemeContent();

ISubscriber usualUser =  new UsualUser("Лала");
usualUser.Subscribe();
usualUser = new UsualUser("Ляман");
usualUser.Subscribe();
content.AddContent();

((MemeContent)content).Publish(new EmailNotify(), new SOLID.SandO.GoodVariration.Classes.SmsNotify());


//Subscriber subscriber = new("Лала");
//Subscriber subscriber2 = new("Ляман");

//NewsFeed feed = new NewsFeed();
//feed.AddNews();
