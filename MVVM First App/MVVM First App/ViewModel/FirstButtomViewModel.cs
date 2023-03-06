using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MVVM_First_App.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_First_App.ViewModel
{
    public class FirstButtomViewModel : ViewModelBase
    {
        private readonly INavigateService _navigationService;
        public FirstButtomViewModel(INavigateService navigationService)
        {
            _navigationService = navigationService;
        }
      
    }
}
