using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сountries.Services.Interfaces
{
    public interface INavigate
    {
        public object? Data { get;set; }
        public void NavigateTo<T>(object? Date = null) where T : ViewModelBase;
    }
}
