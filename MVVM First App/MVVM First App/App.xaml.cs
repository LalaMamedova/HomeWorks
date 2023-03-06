using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using MVVM_First_App.Service;
using MVVM_First_App.View;
using MVVM_First_App.ViewModel;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MVVM_First_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            MainStartup();
            base.OnStartup(e);
        }

        private void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigateService, NavigationClass>();

            Container.RegisterSingleton<MainWindowViewModel>();
            Container.RegisterSingleton<EmptyControlViewModel>();
            Container.RegisterSingleton<FirstButtomViewModel>();
            Container.RegisterSingleton<SecondButtonViewModel>();
            Container.RegisterSingleton<ThirdButtonViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainView();
            mainView.DataContext = Container?.GetInstance<MainWindowViewModel>();
            mainView.ShowDialog();
        }
    }
}
