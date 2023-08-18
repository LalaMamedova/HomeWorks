using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Model.Class
{
    [Serializable]
    public class UserDTO : IUser,IWhiteboard
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Id} {Email}";
        }

    }
}
