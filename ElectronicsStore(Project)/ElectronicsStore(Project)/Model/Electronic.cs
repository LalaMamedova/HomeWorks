using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Model
{
    public class Electronic : INotifyPropertyChanged
    {
        private int count;

        public string? Name { get; set; }
        public string? Category { get; set; }

        public string? ImgPath { get; set; }
        public string? Processor { get; set; }
        public string? Memory { get; set; }
        public int CategoryIndex { get; set; }
        public float Price { get; set; }
        public int Count { get => count; set { count = value; NotifyPropertyChanged(nameof(Count)); } }
        public int ID { get; set; }
        public string StrPrice { get => Price.ToString() + "  ₼ "; }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Name + " " + Category;
        }
    }
}
