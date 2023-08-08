﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WhiteBoardProject.Service.Classes
{
    internal class PasswordService
    {
        private readonly string _password;
        private readonly string _confirm;

        public PasswordService(PasswordBox password, PasswordBox confirm)
        {
            _password = password.Password;
            _confirm = confirm.Password;
        }

        private bool IsLenghtMatch()
        {
            if (_password.Length > 3) return true;

            MessageBox.Show("Длина пароля должна быть больше 3 символов");
            return false;

        }
        public  bool IsMatch()
        {
            Regex passRegex = new("[A-Za-z А-Яа-я 0-9_)]");
            if (passRegex.IsMatch(_confirm) && IsLenghtMatch())
            {
                if (_password == _confirm)
                    return true;
                
                else 
                    MessageBox.Show("Пароли не совпадают");
                
            }
            else if (!passRegex.IsMatch(_confirm) && IsLenghtMatch())
                MessageBox.Show("Недопустимые сиволы");

            return false;
        }
    }
}