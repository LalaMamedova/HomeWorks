using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models.Classes
{
    public class Stationery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("StationeryCategory")]
        public int StationeryCategoryId { get; set; }
        public string StationeryName { get; set; }
        public float Cost { get; set;}
        public int Count { get; set; }  
    }
}
