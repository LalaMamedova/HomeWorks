using AdminPanel.Service.Interfaces;
using AdminPanel.View;
using AdminPanel.ViewModel;
using AdminPanel.Service.Classes;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel
{
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            MainStartup();
        }

        private void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<IAdminService, AdminService>();
            Container.RegisterSingleton<INavigateService, NavigationService>();

            Container.RegisterSingleton<MainAdminViewModel>();
            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<AllProductsViewModel>();
            Container.RegisterSingleton<RedactProductViewModel>();
            Container.Register<AddCategoryViewModel>();
            Container.Register<AddProductViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainAdminWindowView();
            mainView.DataContext = Container?.GetInstance<MainAdminViewModel>();
            mainView.ShowDialog();
        }
    }
}
