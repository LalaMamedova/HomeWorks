using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Download.Data
{
    public class Game : ICloneable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly ReleaseTime { get; set; }
        public List<string> Genre { get; set; } = new();
        public float AvgRating { get; set; }

        public object Clone()
        {
            return new Game { Description = this.Description };
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(); 
            foreach (var item in Genre)
            {
                sb.Append(item.ToString()+" ");
            }

            return $"{Title}\t{ReleaseTime} \t{sb} {Description}";
        }

    }
}
