﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сountries.Dates.Models
{
    public class HeadOfStatePosition
    {
        public int Id { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return Position;
        }
    }
}
