using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Model
{
    public class Check: INotifyPropertyChanged
    {
        private string? userCardNumber;
     
        public ObservableCollection<Basket> Basket { get; set; } = new();
        public string? Barcode { get; set; } = Guid.NewGuid().ToString();
        public float Price { get; set; }
        public string? UserCardNumber
        {
            get => userCardNumber;
            set { userCardNumber = value; NotifyPropertyChanged(nameof(UserCardNumber)); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

     
        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            foreach (var item in Basket)
            {
                stringBuilder.Append(item + "\n");
            }
            return stringBuilder.ToString() + " " + Price + " " +  UserCardNumber;
        }
    }
}
