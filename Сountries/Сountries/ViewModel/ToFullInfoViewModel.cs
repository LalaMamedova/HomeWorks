using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
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
    public class ToFullInfoViewModel:ViewModelBase
    {
        private readonly IMessenger _messenger;
        private INavigate _navigate;
        private CountryContext countryContext = new();
        public Country Country { get; set; } = new();
        public ToFullInfoViewModel(INavigate navigate, IMessenger messenger)
        {
            _messenger = messenger;
            _navigate = navigate;
            _messenger.Register<DataMessager>(this, messenger =>
            {
                if (messenger.Data.GetType().Name == countryContext.GetType().Name)
                {
                    countryContext = messenger.Data as CountryContext;
                }
                else if (messenger.Data.GetType().Name == Country.GetType().Name)
                {
                    Country = messenger.Data as Country;
                    HeadOfStateAndCountry();

                }
            });
        }



        public void HeadOfStateAndCountry()
        {
            Country = countryContext.Countrys.Include(c => c.HeadOfStates).
                Include(c => c.Government).
                Where(x => x.HeadOfStates.Id == Country.CountryRulerId).First(); ;

        }

        public RelayCommand<HeadOfState> ToHeadOfCountry
        {
            get => new((param) =>
            {
                _navigate.NavigateTo<HeadsOfCountryViewModel>(param);
            });
        }
    }
}
