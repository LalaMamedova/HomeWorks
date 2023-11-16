using DeviceLib.Model.Class.DTO.DeviceDTO;

namespace DeviceLib.Model.Class.Device;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    
    public int BrandId { get; set; }
    public Brand Brand { get; set; }

    public ICollection<ProductСharacteristic> CharacteristicValues { get; set; }

}
