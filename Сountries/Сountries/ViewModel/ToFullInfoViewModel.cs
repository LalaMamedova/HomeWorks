using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сountries.Dates.Models;
using Сountries.Services.Classes;
using Сountries.Services.Interfaces;

namespace Сountries.ViewModel
{
    public class ToFullInfoViewModel:ViewModelBase
    {
        public Country Country { get; set; } = new();
        private readonly IMessenger _messenger;
        private INavigate _navigate;
        public ToFullInfoViewModel(INavigate navigate, IMessenger messenger)
        {
            _messenger = messenger;
            _navigate = navigate;
            _messenger.Register<DataMessager>(this, messenger =>
            {
                if (messenger.Data.GetType().Name == Country.GetType().Name)
                {
                    Country = messenger.Data as Country;
                }
            });
        }

        public RelayCommand PrevCommand
        {
            get => new(() =>
            {
                _navigate.NavigateTo<MainViewModel>();
            });
        }
    }
}
