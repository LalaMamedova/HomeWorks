
namespace DeviceLib.Model.Class.Device;

public class CharacteristicType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }

    public ICollection<Сharacteristic> Characteristics { get; set; }
}
