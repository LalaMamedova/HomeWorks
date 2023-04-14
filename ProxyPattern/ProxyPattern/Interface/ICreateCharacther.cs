using ProxyPattern.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Interface
{
    public interface ICreateCharacther
    {
        protected Characther? Characther { get; set; }
        public Characther? CreateCharacther();
    }
}
