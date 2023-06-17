using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
    public class MainViewModel : ViewModelBase
    {
        private INavigate _navigate;
        private ViewModelBase? _currentViewModel;
        private LoadToDb fromDb;
        private CountryContext? countryContext;
        private int SkipCount = 0;
        private int TakeCount = 4;

        public string SearchBar { get; set; } 
        public DataBase Database { get; set; } = new();


        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
    

        public MainViewModel(INavigate navigate)
        {
            _navigate = navigate;

            countryContext = new CountryContext();
            fromDb = new(countryContext);
       
            //countryContext.HeadOfStatePositions.RemoveRange(countryContext.HeadOfStatePositions.Where(x => x.Id < 100));
            //countryContext.HeadOfStates.RemoveRange(countryContext.HeadOfStates.Where(x => x.Id < 100));
            //countryContext.Countrys.RemoveRange(countryContext.Countrys.Where(x => x.Id < 100));
            //countryContext.Governments.RemoveRange(countryContext.Governments.Where(x => x.Id < 100));
            //countryContext.SaveChanges();

            fromDb.LoadFronDb(TakeCount);

        }

        public RelayCommand Next
        {
            get => new(() =>
            {
                DataBase.Countries.Clear();
                try
                {
                    SkipCount += TakeCount;
                    fromDb.ReturnThisCount(SkipCount, TakeCount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            });
        }

        public RelayCommand Prev
        {
            get => new(() =>
            {
                SkipCount -= TakeCount;

                if (SkipCount >= 0)
                {
                    DataBase.Countries.Clear();
                    fromDb.ReturnThisCount(SkipCount,TakeCount);
                }
                else if(SkipCount > countryContext.Countrys.Count() || SkipCount < countryContext.Countrys.Count())
                    SkipCount = 0;

            });
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
                fromDb.LoadFronDb(TakeCount);
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

        public RelayCommand<int> DeleteCountryCommand
        {
            get => new((param) =>
            {
                var YesOrNo = MessageBox.Show($"Вы хотите удалить эту страну?", "?", MessageBoxButton.YesNo);

                if (YesOrNo == MessageBoxResult.Yes)
                {
                    countryContext.Countrys.Remove(countryContext.Countrys.Where(x => x.Id == param).First());
                    
                    countryContext.SaveChanges();
                }

            });
        }
        public RelayCommand<int> ToHeadOfStates
        {
            get => new((param) =>
            {
                _navigate.NavigateTo<HeadsOfCountryViewModel>(countryContext.HeadOfStates.Where(x => x.Id == param).First());
            });
        }
        public RelayCommand<int> ToRedact
        {
            get => new((param) =>
            {
                _navigate.NavigateTo<AddCountryViewModel>(countryContext.Countrys.Where(x => x.Id == param).First());
            });
        }

       
        public RelayCommand<string> FiltrationByGovermentForm
        {
            get => new((param) =>
            {
                DataBase.Countries.Clear();

                foreach (var country in countryContext.Countrys)
                {
                    if (country.Government.GovernmentForm == param)
                    {
                        DataBase.Countries.Add(country);
                    }
                }
            });
        }

        public RelayCommand SearchCommand
        {
            get => new(() =>
            {
                if (!string.IsNullOrEmpty(SearchBar))
                {
                    DataBase.Countries.Clear();

                    var res = countryContext.Countrys.Where(p => EF.Functions.Like(p.CountryName!, $"%{SearchBar}%")).ToList();

                    foreach (var item in res)
                    {
                        DataBase.Countries.Add(item);
                    }
                }
            });
        }
    }
}
