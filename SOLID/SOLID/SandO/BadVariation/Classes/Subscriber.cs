﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SandO.BadVariation.Classes
{
    public class Subscriber//Проблема этого класса в том, что я могу быть пользователем, но могу быть не подписчиком, в данном случаи ты уже подписчик
    {
        public List<News> MyNews { get; set; } = new();//Я может захочу подписаться не на новости, а на рецепты или что то еще, а для того надо будет создать
                                                       //Совсем другой список с уже другим типом класса, что усложняет класс
                                                       //И если например будет 10 классов с различным контентом, то все пользователи будут нагружены лишними и не нужными списками
        public string Login { get; set; }

        public Subscriber(string login)
        {
            Login = login;  
            NewsFeed.Subscribers.Add(this);//Я сразу добавляюсь как подписчик класса Новости, что совсем неправильно
        }
    }
}
