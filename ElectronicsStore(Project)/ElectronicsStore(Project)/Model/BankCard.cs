using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_.Model
{
    public class BankCard
    {
        private string? cardNumber = string.Empty;

        public string? CardNumber 
        {
            get => cardNumber;
            set
            {
                if (value.Length >= 13)
                {
                    cardNumber = value;
                }
                else
                    MessageBox.Show("В карте номера должно быть как минимум 13 цифр","Ошибка");
            }
        }
        public string? UserCardType { get; set; } = string.Empty;
        public int UserCartTypeIndex { get; set; }
    }
}
