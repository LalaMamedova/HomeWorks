using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Classes
{
    public class Task
    {
        public string? Discription { get; set; }
        public bool Important { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public bool IsSelected { get; set; } = false;

        public Task(string? taskName, bool important, DateTime? date, bool ischeked)
        {
            Discription = taskName;
            Important = important;
            Date = date;
            IsSelected = ischeked;
        }
        public Task() {}

        public override string ToString()
        {
            if (Important == true)
                return Discription + " : " + "Важно" + " : " + Date?.ToShortDateString();

            else
                return Discription + " : " + "Неважно" + " : " + Date?.ToShortDateString();
        }
    }
}
