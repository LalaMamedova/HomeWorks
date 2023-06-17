using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime CreateDate { get; set; } = DateTime.Parse("01/05/800");
        public string MapImgLink { get; set; }
        public float Population { get; set; }
        public double Area { get; set; }
        public double GDP { get; set; }
        public string Himn { get; set; }

        public int CountryRulerId { get; set; }
        public HeadOfState HeadOfStates { get; set; } = new();

        public int GovermentTypeId { get; set; }
        public Government Government { get; set; } = new();

        public Country(int id, string countryName, DateTime createDate, string mapImgLink, float population, double area, double gDP, int govermentTypeId, Government government, int countryRuler, string himn)
        {
            Id = id;
            CountryName = countryName;
            CreateDate = createDate;
            MapImgLink = mapImgLink;
            Population = population;
            Area = area;
            GDP = gDP;
            GovermentTypeId = govermentTypeId;
            Government = government;
            CountryRulerId = countryRuler;
            Himn = himn;
        }

        public Country() { }

        public override string ToString()
        {
            return $"{CountryName} {CreateDate.ToShortDateString()} ";
        }
    }
}
