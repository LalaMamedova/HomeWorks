﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltrationOnEntity.Models.Class
{
    public class DataBase
    {
        public static ObservableCollection<Product> Products { get; set; } = new();
        public static ObservableCollection<Category> Categorys { get; set; } = new();
    }
}
