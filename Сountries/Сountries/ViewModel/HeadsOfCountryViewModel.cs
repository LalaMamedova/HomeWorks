using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Сountries.Dates.Contexts;
using Сountries.Dates.Models;
using Сountries.Services.Classes;
using Сountries.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Сountries.ViewModel
{
    public class HeadsOfCountryViewModel:ViewModelBase
    {
        private CountryContext? countryContext = new();
        private ViewModelBase? _currentViewModel;
        private readonly IMessenger _messenger;
        private INavigate _navigate;
        public HeadOfState HeadOfState { get; set; } = new();
        public DataBase Database { get; set; } = new();


        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }
       
        public HeadsOfCountryViewModel(INavigate navigate, IMessenger messenger)
        {
            _messenger = messenger;
            _navigate = navigate;
            _messenger.Register<DataMessager>(this, messenger =>
            {
                if (messenger.Data.GetType().Name == countryContext.GetType().Name)
                {
                    countryContext = messenger.Data as CountryContext;
                }
                else if (messenger.Data.GetType().Name == HeadOfState.GetType().Name)
                {
                    HeadOfState = messenger.Data as HeadOfState;
                    FromHeadOfState();
                }
            });
        }

        public void FromHeadOfState()
        {
            var headOfStates = countryContext.HeadOfStates.Include(c => c.Position).Where(x => x.Position.Id == HeadOfState.PositionId).First();
            HeadOfState = headOfStates;
        }
    }
}
