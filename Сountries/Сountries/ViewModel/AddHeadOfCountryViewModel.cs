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
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Сountries.ViewModel
{
    public class AddHeadOfCountryViewModel:ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly IMessenger _messenger;
        private INavigate _navigate;
        private CountryContext? countryContext = new();

        public HeadOfState HeadOfState { get; set; } = new();
        public DataBase Database { get; set; } = new();


        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }

        public AddHeadOfCountryViewModel(INavigate navigate, IMessenger messenger)
        {
            _messenger = messenger;
            _navigate = navigate;
            _messenger.Register<DataMessager>(this, messenger =>
            {
                if (messenger.Data.GetType().Name == countryContext.GetType().Name)
                {
                    countryContext = messenger.Data as CountryContext;
                }
            });
        }

        public RelayCommand AddCommand
        {
            get => new(()=>
            {
                try
                {
                    HeadOfState.PositionId = countryContext.HeadOfStatePositions.Where(x => x.Position == HeadOfState.Position.Position).First().Id;
                    
                    countryContext.HeadOfStates.Add(HeadOfState);
                    countryContext.SaveChanges();
                    MessageBox.Show($"{HeadOfState} был добавлен");
                    HeadOfState = new();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
               
            });
        }
    }
}
