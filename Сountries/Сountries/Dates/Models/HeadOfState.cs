using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сountries.Dates.Models
{
    public class HeadOfState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public string? Patronymic { get; set; } 

        public string FullName { get =>  $"{Name} {Surname} {Patronymic}";}

        public DateTime BirthDate { get; set; } = DateTime.Parse("06/06/1900");
        public string? Description { get; set; } 
        public string ImgLink { get; set; }


        public int PositionId { get; set; }
        public HeadOfStatePosition Position { get; set; } = new();

        public override string ToString()
        {
            return FullName;
        }


    }
}
