﻿using SOLID.BadVariation.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Interface
{
    public interface IContent//Абстрактный интерфейс
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public static List<ISubscriber> Subscribers { get; set; }//Чтобы у всех классов был список с их подписчиками
        public void AddContent();
    

    }
}
