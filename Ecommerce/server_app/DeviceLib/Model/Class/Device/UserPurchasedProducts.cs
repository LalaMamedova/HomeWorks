using server_app.Model.Class.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceLib.Model.Class.Device
{
    public class UserPurchasedProducts
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Product PurchasedProduct { get; set; }
    }
}
