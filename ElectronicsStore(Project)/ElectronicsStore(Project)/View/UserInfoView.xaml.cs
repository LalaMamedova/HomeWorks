﻿using ElectronicsStore_Project_.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ElectronicsStore_Project_.View
{
    /// <summary>
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfoView : Window
    {
        private bool check = false;
        public UserInfoView()
        {
            InitializeComponent();
            DataContext = App.Container.GetInstance<UserInfoViewModel>();

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            check = true;
            this.Close();
        }

        private void UserInfo_Deactivated(object sender, EventArgs e)
        {
            if (!check)
            {
                this.Close();
            }
        }
    }
}
