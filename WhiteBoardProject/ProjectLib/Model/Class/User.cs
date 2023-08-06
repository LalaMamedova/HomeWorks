using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Model.Class
{
    public class User : IUser
    {
        public int Id {get;set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserArt UserArt { get; set; }
        public IPEndPoint IPEndPoint { get; set; }
        public List<UserArt> UserArts { get; set; } = new();
    }
}
