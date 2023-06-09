using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сountries.Dates.Contexts;
using Сountries.Dates.Models;
using Сountries.Services.Classes;
using Сountries.Services.Interfaces;

namespace Сountries.ViewModel
{
    public class AddCountryViewModel:ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly IMessenger _messenger;
        private INavigate _navigate;
        private CountryContext? countryContext = new();

        public Country Country { get; set; } = new();
        public DataBase Database { get; set; } = new();


        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }

        public AddCountryViewModel(INavigate navigate,IMessenger messenger)
        {
            _messenger = messenger;
            _navigate = navigate;
            _messenger.Register<DataMessager>(this, messenger =>
            {
                if(messenger.Data.GetType().Name == countryContext.GetType().Name)
                {
                    countryContext = messenger.Data as CountryContext;
                }
            });
        }

        public RelayCommand AddCommand
        {
            get => new(() => 
            {

                countryContext.Countrys.Add(Country);
                countryContext.SaveChanges();
                Country = new();
            });
        }

        public RelayCommand AddMap
        {
            get => new(() =>
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.jfif";

                fileDialog.ShowDialog();
                Country.MapImgLink = fileDialog.FileName;
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
