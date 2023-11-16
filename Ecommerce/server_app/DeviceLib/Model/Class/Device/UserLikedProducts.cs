using server_app.Model.Class.User;

namespace DeviceLib.Model.Class.Device;

public class UserLikedProducts
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public Product LikedProduct { get; set; }
}
