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
    public class User : IUser,IWhiteboardcs
    {
        [NonSerialized]
        private IPEndPoint _ipEndPoint;
        public IPEndPoint IPEndPoint
        {
            get => _ipEndPoint;
            set => _ipEndPoint = value;
        }
        public int Id {get;set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserArt UserArt { get; set; }
        public ICollection<UserArt> UserArts { get; set; }

        public override string ToString()
        {
            return $"{Id} {Username} {Email}";
        }
    }
}
