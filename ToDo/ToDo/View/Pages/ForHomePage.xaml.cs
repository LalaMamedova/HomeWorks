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
        public ObservableCollection<Task> AllTasks { get; set; } = new();

        public ForHomePage()
        {
            InitializeComponent();
     
            //TodoListBox.ItemsSource = todoListForHome.AllTasks;
        }
    
        private void RedactButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            
            todoListForHome.AllTasks.RemoveAt(TodoListBox.SelectedIndex);
            TodoListBox.ItemsSource = todoListForHome.AllTasks;
           
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTheTaskView addTaskModel = new();
            addTaskModel.ShowDialog();

            todoListForHome.AllTasks.Add(addTaskModel.AddTask());
            

            //SerializeAndWrite.WriteAndSerialize<ToDoList>("ForHome.json", todoListForHome);
        }

    }
}
