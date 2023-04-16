using SOLID.SandO.GoodVariration.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SandO.GoodVariration.Interface
{
    public interface ISubscriber//Интерфейс подписчика
    {
        public string Login { get; set; }
        public List<IContent> contents { get; set;}
        public void Subscribe();
        public void Unsubscribe();

       
    }
}
