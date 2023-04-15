using FacadePattern.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Interface
{
    public interface IRequest
    {
        public Package Package { get; set; }

    }
}
