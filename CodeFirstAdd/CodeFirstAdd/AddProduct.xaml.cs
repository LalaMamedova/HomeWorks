using CodeFirstAdd.Date.DataContext;
using CodeFirstAdd.Date.Models.Class;
using CodeFirstAdd.Models.Class;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CodeFirstAdd
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public Product Product { get; set; } = new Product();
        public DataBase DataBase { get; set; } = new DataBase();

        ClothingStoreContext connection;

        public AddProduct(ClothingStoreContext context)
        {
            InitializeComponent();
            connection = context;
        }
       
        private void CategoryIndex(string category)
        {
            for (int i = 0; i < DataBase.Categorys.Count; i++)
            {
                if (DataBase.Categorys[i].CategoryName == category)
                {
                    MessageBox.Show($"Вы выбрали категорию: {DataBase.Categorys[i].CategoryName}");
                    Product.CategoryName = DataBase.Categorys[i].CategoryName;
                    Product.CategoryId = i ;
                    break;
                }
            }
        }
        private void CategoryChoice_Click(object sender, RoutedEventArgs e)
        {
            Button category = (Button)sender;

            CategoryIndex(category.Content.ToString());
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
