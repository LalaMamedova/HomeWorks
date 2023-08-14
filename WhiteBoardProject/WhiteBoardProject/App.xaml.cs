using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.Interface;
using WhiteBoardProject.View;
using WhiteBoardProject.ViewModel;

namespace WhiteBoardProject
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

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<RegistrationViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<SendEmailViewModel>();
            Container.Register<DrawViewModel>();

        }

        private void MainStartup()
        {
            try
            {
                var mainView = new MainView();
                mainView.DataContext = Container?.GetInstance<MainViewModel>();
                mainView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
