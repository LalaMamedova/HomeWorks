using AsyncAwaitCrud.Models.Class;
using AsyncAwaitCrud.Models.DatabaseContext;
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

namespace AsyncAwaitCrud
{
    /// <summary>
    /// Interaction logic for AddFlower.xaml
    /// </summary>
    public partial class AddFlower : Window
    {
        private FlowerDbContext context;
        private bool IsRedact = false;
        public Flower Flower { get; set; } = new();
        public MyColors MyColors { get; set; } = new();
        public AddFlower(FlowerDbContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        public AddFlower(Flower flower)
        {
            InitializeComponent();
            Flower = flower;
            IsRedact = true;
        }

        private async Task Add()
        {
            try
            {
                await context.AddAsync(Flower);
                await context.SaveChangesAsync();
                MessageBox.Show($"{Flower.Name} был добавлен");
                Flower = new();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task Redact()
        {
            try
            {
                context.Update(Flower);
                await context.SaveChangesAsync();
                MessageBox.Show($"{Flower.Name} был изменен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(IsRedact)
            {
               await Redact();
               IsRedact=false;
            }
            else 
                await Add();

        }
    }
}
