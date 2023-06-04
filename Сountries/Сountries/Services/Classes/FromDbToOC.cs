using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сountries.Dates.Contexts;
using Сountries.Dates.Models;

namespace Сountries.Services.Classes
{
    public class FromDbToOC
    {
        public CountryContext CountryContext { get; set; }
        public FromDbToOC(CountryContext Contex) { CountryContext = Contex; }

        public void LoadFronDb()
        {
            foreach (var country in CountryContext.Countrys)
            {
                DataBase.Countries.Add(country);
            }

            foreach (var country in CountryContext.Governments)
            {
                DataBase.Governments.Add(country);
            }
        }

        
    }
}
