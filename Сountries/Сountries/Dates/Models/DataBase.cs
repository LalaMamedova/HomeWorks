using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сountries.Dates.Models
{
    public class DataBase
    {
        public static ObservableCollection<Country> Countries { get; set;} = new();
        public static ObservableCollection<Government> Governments { get; set; } = new();

        public DataBase() {
            Governments.Add(new Government() { Id = 1, GovernmentForm = "Монархия" });
            Governments.Add(new Government() { Id = 2, GovernmentForm = "Республика" });
            Governments.Add(new Government() { Id = 3, GovernmentForm = "Диктатура" });
            Governments.Add(new Government() { Id = 4, GovernmentForm = "Тоталитаризм" });


            //Countries.Add(new Country()
            //{
            //    Id = 1,
            //    CountryName = "United States",
            //    CreateDate = new DateTime(1776, 7, 4),
            //    MapImgLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a5/Map_of_USA_with_state_names.svg/800px-Map_of_USA_with_state_names.svg.png",
            //    Population = 331000000,
            //    Area = 9629091.42,
            //    GDP = 22794000,
            //    GovermentType = 1,
            //    Government = Governments[0]

            //});

            //Countries.Add(new Country()
            //{
            //    Id = 2,
            //    CountryName = "Germany",
            //    CreateDate = new DateTime(1871, 1, 18),
            //    MapImgLink = "https://www.nationsonline.org/maps/germany-administrative-map.jpg",
            //    Population = 83100000,
            //    Area = 357022.0,
            //    GDP = 4039080,
            //    GovermentType = 1,
            //    Government = Governments[0]

            //});

            //Countries.Add(new Country()
            //{
            //    Id = 4,
            //    CountryName = "China",
            //    CreateDate = new DateTime(221, 1, 1),
            //    MapImgLink = "https://www.worldometers.info/img/maps/china_road_map.gif",
            //    Area = 9640011.0,
            //    GDP = 16642259,
            //    GovermentType = 2,
            //    Government = Governments[2]

            //});
        }
    }
}
