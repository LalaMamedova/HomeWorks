using server_app.Model.Class;
using DeviceLib.Model.Class.Device;

namespace server_app.Model.Class.User
{
    public class User 
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password {get;set; }

        public int UsersDevicesId { get; set; }
        public ICollection<UserLikedProducts> UsersLikedDevices { get; set; }
        public ICollection<UserPurchasedProducts> UsersPurchasedDevices { get; set; }

    }
}
