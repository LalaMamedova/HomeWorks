using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Model
{
    public  class DataBase
    {
        public static ObservableCollection<Electronics?>? AllElectronics { get; set; } = new();
        public static ObservableCollection<Category?>? AllCategory { get; set; } = new();

    }
}
