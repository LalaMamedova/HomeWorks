using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UdpServer
{
    public class User
    {
        public string Username { get; set; }
        public IPEndPoint IPEndPoint { get; set; }
    }
}
