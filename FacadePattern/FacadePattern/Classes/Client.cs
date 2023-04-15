using FacadePattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes
{
    public class Client : IClient
    {
        public List<Package> Goods { get; private set; } = new();
        public List<IRequest> Myrequest { get; set; } = new();
        public string Adress { get; set; }
        public float Bill { get; set; }
        public bool HasACard { get; set; } = false;

    }
}
