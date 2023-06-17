using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сountries.Dates.Models
{
    public class Government
    {
        public int Id { get;set; }
        public string? GovernmentForm { get; set; }



        public Government() { }

        public Government(int id, string? governmentForm)
        {
            Id = id;
            GovernmentForm = governmentForm;
        }


        public override string ToString()
        {
            return GovernmentForm;
        }
    }
}
