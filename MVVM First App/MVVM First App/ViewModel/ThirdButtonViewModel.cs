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
    public class ThirdButtonViewModel: ViewModelBase
    {
        private readonly INavigateService _navigationService;

        public ThirdButtonViewModel(INavigateService navigationService)
        {
            _navigationService = navigationService;
        }

       
    }
}
