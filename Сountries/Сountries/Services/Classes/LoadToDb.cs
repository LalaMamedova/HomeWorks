using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сountries.Dates.Contexts;
using Сountries.Dates.Models;

namespace Сountries.Services.Classes
{
    public class LoadToDb
    {
        public CountryContext countryContext { get; set; } 

        public LoadToDb(CountryContext Contex) { countryContext = Contex; }

        public void LoadFronDb()
        {
            DataBase.Countries.Clear();
            foreach (var country in countryContext.Countrys)
            {
                DataBase.Countries.Add(country);
            }

            //foreach (var country in CountryContext.Governments)
            //{
            //    DataBase.Governments.Add(country);
            //}
        }

        public void  Filtration<T>(Func<Country, T> funck)
        {
            IEnumerable<Country> orderedCountry  = countryContext.Countrys.OrderBy(funck);
            DataBase.Countries.Clear();

            foreach (Country country in orderedCountry)
            {
                DataBase.Countries.Add(country);
            }
        }
        
    }
}
