using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Сountries.Dates.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public DateTime CreateDate { get; set; }
        public string MapImgLink { get; set; }
        public float Population { get; set; }
        public double Area { get; set; }
        public double GDP { get; set; }
        public string CountryRuler { get; set; }
        public string Himn { get; set; }


        public int? GovermentType { get; set; }
        public Government Government { get; set; }

        public Country(int id, string countryName, DateTime createDate, string mapImgLink, float population, double area, double gDP, int? govermentType, Government government)
        {
            Id = id;
            CountryName = countryName;
            CreateDate = createDate;
            MapImgLink = mapImgLink;
            Population = population;
            Area = area;
            GDP = gDP;
            GovermentType = govermentType;
            Government = government;
        }

        public Country() { }
    }
}
