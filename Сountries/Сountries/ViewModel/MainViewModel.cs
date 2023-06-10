﻿using GalaSoft.MvvmLight;
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
        private LoadToDb fromDb;
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

            fromDb = new(countryContext);
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

        public RelayCommand RefreshCommand
        {
            get => new(() =>
            {
                fromDb = new(countryContext);
                fromDb.LoadFronDb();
            });
        }

        public RelayCommand FiltrationByAlph
        {
            get => new(() =>
            {
                fromDb.Filtration<string>(x => x.CountryName); 
            });
        }
        public RelayCommand FiltrationByGDP
        {
            get => new(() =>
            {
                fromDb.Filtration<double>(x => x.GDP);
            });
        }
        public RelayCommand FiltrationByPopulation
        {
            get => new(() =>
            {
                fromDb.Filtration<float>(x => x.Population);
            });
        }

        public RelayCommand<string> FiltrationByGovermentForm
        {
            get => new((param) =>
            {
                try
                {
                    DataBase.Countries.Clear();

                    foreach (var country in countryContext.Countrys)
                    {
                        if (country.Government.GovernmentForm == param)
                        {
                            DataBase.Countries.Add(country);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                

            });
        }
    }
}
