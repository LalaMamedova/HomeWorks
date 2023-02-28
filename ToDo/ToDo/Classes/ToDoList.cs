using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Classes
{
    public class ToDoList
    {
        public ObservableCollection<Task> AllTasks { get; set; } = new();
        public ToDoList()
        {
            //AllTasks.Add((new Task("Кино", true, DateTime.Parse("12.12.2002"), false)));
            //AllTasks.Add((new Task("Пойти в кафе", false, DateTime.Parse("05.08.2202"), true)));
            //AllTasks.Add((new Task("Купить мороженое", true, DateTime.Parse("08.06.2021"), true)));
            //AllTasks.Add((new Task("Работай плиз", false, DateTime.Parse("09.06.2023"), true)));
        }

    }
}
