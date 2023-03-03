using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_First_App.ViewModel
{
    internal class MainWindowViewModel: ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Set(ref _currentViewModel, value);
            }
        }

    }
}
