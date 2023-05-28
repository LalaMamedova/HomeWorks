using FiltrationOnEntity.Models.Class;
using FiltrationOnEntity.Models.Context;
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

namespace FiltrationOnEntity.Views
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : Window
    {
        EcommerceContext connection = new EcommerceContext();
        public DataBase DataBase { get; set; } = new();
        public Product Product { get; set; } = new();
        public AddView()
        {
            InitializeComponent();
        }

        private void CategoryChoice_Click(object sender, RoutedEventArgs e)
        {
            Button category = (Button)sender;

            CategoryIndex(category.Content.ToString());
        }

        private void CategoryIndex(string category)
        {
            for (int i = 0; i < DataBase.Categorys.Count; i++)
            {
                if (DataBase.Categorys[i].CategoryName == category) 
                {
                    Product.CategoryId = i+1;
                }
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (Product.CategoryId != null)
            {
                connection.Products.Add(Product);
                connection.SaveChanges();
                MessageBox.Show(Product.ToString() + " добавлен");
                Product = new();
            }
            else
                MessageBox.Show("Выберите категорию");
        }
    }
}
