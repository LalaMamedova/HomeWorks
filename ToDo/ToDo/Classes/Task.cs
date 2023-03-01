using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Classes
{
   public enum Importance { Неважно =0, Важно}
    public class Task
    {
        public string? Discription { get; set; }
        public Importance Important { get; set; } = 0;
        public DateTime? Date { get; set; }  = DateTime.Now;
        public bool IsSelected { get; set; } = false;

        public Task(string? taskName, Importance important, DateTime? date, bool ischeked)
        {
            Discription = taskName;
            Important = important;
            Date = date;
            IsSelected = ischeked;
        }
        public Task() {}
        public override string ToString()
        {
            return Discription + Date;
        }

    }
}
