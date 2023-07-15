using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitCrud.Models.Class
{
    public class Flower
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public string? Img { get; set; }

    }
}
