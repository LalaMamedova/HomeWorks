using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel.DataAnnotations;
using ElectronicsStore_Project_.Service.Classes;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;

namespace ElectronicsStore_Project_.Model
{
    public class Customer:INotifyPropertyChanged
    {
        private string email;
        private string login;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Email
        {
            get => email;
            set
            {
                if (EmailCheck(value))
                    email = value;
                else
                    MessageBox.Show("Email должен содержать '@' и '.'", "Ошибка введение email");
            }
        }
        public string Login
        {
            get => login;
            set
            {
                Regex loginEx = new("[A-Za-zА-Яа-я0-9-_]");
                if (loginEx.IsMatch(value))
                {
                    login = value;
                    NotifyPropertyChanged(nameof(Login));
                }
                else
                    MessageBox.Show("Логин содержит недопустимые символы", "Ошибка введение логина");
            }
        }


        public string? Password { get; set; } 
        public string? ConfirmPassword { get; set; }
        public BankCard? Card { get; set; } = new();
        public int ID { get; set; }

        public bool EmailCheck(string email)
        {
            var checkemail = new EmailAddressAttribute();
            if (!checkemail.IsValid(email) || !email.Contains('.') || string.IsNullOrEmpty(email)) { return false; }
            return true;

        }

        
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
