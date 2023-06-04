using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Сountries.Services.Interfaces;

namespace Сountries.Services.Classes
{
    internal class Navigate : INavigate
    {
        private readonly IMessenger _messenger;
        public object Data { get; set; }

        public Navigate(IMessenger messenger)
        {
            _messenger = messenger;
        }


        void INavigate.NavigateTo<T>(object? Data)
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = typeof(T)
            });


            if (Data != null)
            {
                _messenger.Send(new DataMessager()
                {
                    Data = Data
                });
            }
        }
    }
}
