using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_.Model
{
    public class Customer
    {
        private string email;
        private string login;

        public string Email
        {
            get => email;
            set
            {
                if (EmailCheck(value))
                    email = value;
                else
                    MessageBox.Show("Email не может содержать все кроме букв,чисел, точек и тире", "Ошибка введение email");
            }
        }
        public string Login
        {
            get => login;
            set
            {
                Regex loginEx = new("A-Za-z0-9-_");
                if (loginEx.IsMatch(value))
                    login = value;
                else
                    MessageBox.Show("Логин содержит недопустимые символы", "Ошибка введение логина");
            }
        }


        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        public bool EmailCheck(string email)
        {
            if (!email.Contains('@') && !email.Contains('.') || string.IsNullOrEmpty(email)) return false;
            return true;

        }
        public Customer(string login, string email, string password, string confirmPassword) 
        {
            this.Login = login;
            this.Password = password;
            this.ConfirmPassword = confirmPassword;
            this.Email = email;
        }

        public Customer() { }

        public override string ToString()
        {
            return $"{Login} {Email}";
        }
    }
}
