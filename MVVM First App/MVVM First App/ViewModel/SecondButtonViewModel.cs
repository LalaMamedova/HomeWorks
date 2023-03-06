using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVM_First_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_First_App.ViewModel
{
    public class SecondButtonViewModel: ViewModelBase
    {
        private readonly INavigateService _navigationService;

        public SecondButtonViewModel(INavigateService navigationService)
        {
            _navigationService = navigationService;
        }

       
    }
}
