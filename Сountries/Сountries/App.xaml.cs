using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore.Metadata;
using SimpleInjector;
using Сountries.Services.Classes;
using Сountries.Services.Interfaces;
using Сountries.View;
using Сountries.ViewModel;

namespace Сountries
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SimpleInjector.Container Container { get; set; } = new();

        protected override void OnStartup(StartupEventArgs e)
        {
            Registers();
            MainStartup();
        }

        private void Registers()
        {
            Container.RegisterSingleton<INavigate, Navigate>();
            Container.RegisterSingleton<IMessenger, Messenger>();

            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<AddCountryViewModel>();
            Container.RegisterSingleton<ToFullInfoViewModel>();

        }

        private void MainStartup()
        {
            var mainView = new HomeView();
            mainView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainView.DataContext = Container?.GetInstance<HomeViewModel>();
            mainView.ShowDialog();
        }
    }
}
