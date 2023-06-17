using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private bool isRedact = false;
        private CountryContext? countryContext = new();
        public string FullName { get; set; }
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
                else if(messenger.Data.GetType().Name == Country.GetType().Name)
                {
                    Country = messenger.Data as Country;
                    isRedact = true;
                }
            });
        }

        public void Redact()
        {
            Country.HeadOfStates = countryContext.HeadOfStates.
                        Where(x => x.Name + " " + x.Surname + " " + x.Patronymic == FullName).First();
            Country.Government = countryContext.Governments.Where(x => x.GovernmentForm == Country.Government.GovernmentForm).First();

            countryContext.Countrys.Update(Country);
            countryContext.SaveChanges();

        }

        public RelayCommand AddCommand
        {
            get => new(() => 
            {
                try
                {
                    if (isRedact == false)
                    {
                        Country.HeadOfStates = countryContext.HeadOfStates.
                        Where(x => x.Name + " " + x.Surname + " " + x.Patronymic == FullName).
                        ToList().First();

                        Country.Government = countryContext.Governments.Where(x => x.GovernmentForm == Country.Government.GovernmentForm).First();

                        countryContext.Countrys.Add(Country);
                        countryContext.SaveChanges();
                        MessageBox.Show($"{Country.CountryName} был добавлен в базу данных");
                        Country = new();
                    }
                    else
                    {
                        Redact();
                        MessageBox.Show($"{Country.CountryName} был изменен");
                        Country = new();
                        isRedact = false;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
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

        public RelayCommand AddHeadState
        {
            get => new(() =>
            {
                _navigate.NavigateTo<AddHeadOfCountryViewModel>(countryContext);
            });
        }

    }
}
