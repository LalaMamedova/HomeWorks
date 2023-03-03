using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ToDo.Classes.SerializeService;
using Task = ToDo.Classes.Task;
using ToDo.Classes;
using System.IO;
using System.ComponentModel;

namespace ToDo.View.Pages
{
    /// <summary>
    /// Interaction logic for ForHomePage.xaml
    /// </summary>
    public partial class ForHomePage : Page
    {
        public ObservableCollection<Task> TasksForHome { get; set; } = new();
        
        public ForHomePage()
        {
            InitializeComponent();

            if (FIleService.CheckFile("ForHome.json"))
                TasksForHome = SerializeAndWrite.ReadAndDesiarile<ObservableCollection<Task>>("ForHome.json");

            TodoListBox.ItemsSource = TasksForHome;
        }
       
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            TasksForHome.RemoveAt(TodoListBox.SelectedIndex);
            
            SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForHome.json", TasksForHome);

        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTheTaskView addTaskModel = new();

            addTaskModel.ShowDialog();
            var res = addTaskModel.AddTask();
            if (res != null)
            {
                TasksForHome.Add(addTaskModel.AddTask());
                TodoListBox.ItemsSource = TasksForHome;
                SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForHome.json", TasksForHome);
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForHome.json", TasksForHome);
        }

        private void ComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForHome.json", TasksForHome);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForHome.json", TasksForHome);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

       
    }
}
