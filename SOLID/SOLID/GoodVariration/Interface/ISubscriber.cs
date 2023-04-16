using SOLID.GoodVariration.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GoodVariration.Interface
{
    public interface ISubscriber//Интерфейс подписчика
    {
        public string Login { get; set; }
        public List<IContent> contents { get; set;}
        public void Subscribe();
        public void Unsubscribe();

       
    }
}
