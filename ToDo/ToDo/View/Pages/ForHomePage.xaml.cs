using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using ToDo.Classes.SerializeService;
using ToDo.Classes;
using ToDo.View;

using Task = ToDo.Classes.Task;

namespace ToDo.View.Pages
{
    /// <summary>
    /// Interaction logic for ForHomePage.xaml
    /// </summary>
    public partial class ForHomePage : Page
    {
        public ToDoList todoListForHome = new();
        public ForHomePage()
        {
            InitializeComponent();
            todoListForHome = SerializeAndWrite.ReadAndDesiarile<ToDoList>("ForHome.json");

            //todoListForHome.AllTasks.Add((new Task("Кино", true, DateTime.Parse("12.12.2002"), false)));
            //todoListForHome.AllTasks.Add((new Task("Пойти в кафе", false, DateTime.Parse("05.08.2202"), true)));
            //todoListForHome.AllTasks.Add((new Task("Купить мороженое", true, DateTime.Parse("08.06.2021"), true)));
            //todoListForHome.AllTasks.Add((new Task("Работай плиз", false, DateTime.Parse("09.06.2023"), true)));
            TodoListBox.ItemsSource = todoListForHome.AllTasks;
        }
    
        private void RedactButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            todoListForHome = SerializeAndWrite.ReadAndDesiarile<ToDoList>("ForHome.json");
            todoListForHome.AllTasks.RemoveAt(TodoListBox.SelectedIndex);
            TodoListBox.ItemsSource = todoListForHome.AllTasks;
            SerializeAndWrite.WriteAndSerialize<ToDoList>("ForHome.json", todoListForHome);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTheTaskView addTaskModel = new();
            addTaskModel.ShowDialog();
            todoListForHome.AllTasks.Add(addTaskModel.AddTask());
            TodoListBox.ItemsSource = todoListForHome.AllTasks;

            SerializeAndWrite.WriteAndSerialize<ToDoList>("ForHome.json", todoListForHome);
        }

    }
}
