using AdminPanel.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.Model
{
    public class Electronics
    {
        private float price;
        private int count;
        

        //[Required]
        public string? Name { get; set; }
        public string? Category { get; set; }

        //[Required]
        public string ImgPath { get; set; } = @"D:\HomeWorks\WPF\ElectronicsStore(Project)\Project\Electronics.jpg";
        public string? Processor { get; set; }
        public string? Memory { get; set; }
        public int CategoryIndex { get; set; }

        //[Required]
        public float Price
        {
            get => price;
            set
            {
                if (value == float.Parse(value.ToString()))price = value;
                
                else throw new ArgumentException("Неправильные данные");
            }
        }

        

        //[Required]
        public int Count
        {
            get => count;
            set
            {
                if (value == Int32.Parse(value.ToString())) count = value;
                
                else throw new ArgumentException("Неправильные данные");
            }
        }
        public int ID { get; set; }
        public string? StrPrice { get => Price.ToString() + " манат"; }

        
        public Electronics? CheckNulls()
        {
            if (this.Count != 0 && this.Price != 0 &&
                !string.IsNullOrEmpty(this.Name) &&
                !string.IsNullOrEmpty(this.Category) &&
                !string.IsNullOrEmpty(this.ImgPath))
                return this;

            return null;
        }

        public override string ToString()
        {
            return Name + " " + Category;
        }

    }
}
