using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using ElectronicsStore_Project_.View;
using ElectronicsStore_Project_.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using SimpleInjector;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_
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
            Container.RegisterSingleton<ICustomerService, CustomerService>();
            Container.RegisterSingleton<INavigateService, NavigationService>();

            Container.RegisterSingleton<MainStoreViewModel>();
            Container.RegisterSingleton<AuthViewModel>();
            Container.RegisterSingleton<RegistrationViewModel>();
            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<SelectedCategoryProductsViewModel>();
            Container.Register<ProductInfoViewModel>();

        }

        private void MainStartup()
        {
            var mainView = new StoreMainView();
            mainView.DataContext = Container?.GetInstance<MainStoreViewModel>();
            mainView.ShowDialog();
        }
    }
}
