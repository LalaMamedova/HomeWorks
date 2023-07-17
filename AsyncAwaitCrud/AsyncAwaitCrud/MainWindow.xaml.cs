using AsyncAwaitCrud.Models.Class;
using AsyncAwaitCrud.Models.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwaitCrud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FlowerDbContext context = new();
        public ObservableCollection<Flower> FlowerList { get; set; }  = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {

            //Parallel.ForEach(context.Flowers, async flower =>
            //{
            //    await Dispatcher.Invoke(async () =>
            //     {
            //       FlowerList.Add(flower);
            //   });
            //});


            context.Flowers.ToList().ForEach(flower =>
            {
                FlowerList.Add(flower);
            });

            FlowerList.Add(new Models.Class.Flower()
            {
                Id = -1,
                Color = MyColors.ColorsList[0],
                Name = "Лаванда",
                Price = 23.5f,
                Img = "https://shop.evalar.ru/upload/iblock/f5d/f5db2928a135c555b00a442a8b778b92.jpg"
            }) ;

            FlowerList.Add(new Models.Class.Flower()
            {
                Id = -2,
                Color = MyColors.ColorsList[1],
                Name = "Роза",
                Price = 555.5f,
                Img = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Rosa_Red_Chateau01.jpg/300px-Rosa_Red_Chateau01.jpg"
            });


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AddFlower AddFlower = new(context) ;
            AddFlower.ShowDialog();
        }

        private async void RedactButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter != null)
            {
                AddFlower AddFlower =  new(await context.Flowers
                    .Where(x => x.Id == (int)button.CommandParameter)
                    .FirstAsync()!);

                AddFlower.ShowDialog();

            }
            
        }

        private async void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter != null)
            {
                Flower flower = await context.Flowers
                .Where(x => x.Id == (int)button.CommandParameter).FirstAsync();

                context.Flowers.Remove(flower);
                await context.SaveChangesAsync();
                MessageBox.Show($"Цветы были удалены");

            }

        }
    }
}
