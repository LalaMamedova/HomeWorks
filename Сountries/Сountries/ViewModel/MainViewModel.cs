using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сountries.Dates.Contexts;
using Сountries.Dates.Models;
using Сountries.Services.Classes;
using Сountries.Services.Interfaces;

namespace Сountries.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private INavigate _navigate;
        private IMessenger _messenger;
        private ViewModelBase? _currentViewModel;
        private CountryContext? countryContext;
        public DataBase Database { get; set; } = new();

        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
    
        public MainViewModel(INavigate navigate, IMessenger messenger)
        {
            _navigate = navigate;
            _messenger = messenger;

            countryContext = new CountryContext();
            FromDbToOC fromDb = new (countryContext);

            fromDb.LoadFronDb();
        }

        public RelayCommand AddCountryCommand
        {
            get => new(() =>
            {
                _navigate.NavigateTo<AddCountryViewModel>(countryContext);
            });
        }

        public RelayCommand<int> ToFullInfoCommand
        {
            get => new((param) =>
            {
                var country = DataBase.Countries.Where(x => x.Id == param);
                
                Country selectedCountry = country.FirstOrDefault();
                _navigate.NavigateTo<ToFullInfoViewModel>(selectedCountry);
            });
        }

    }
}
