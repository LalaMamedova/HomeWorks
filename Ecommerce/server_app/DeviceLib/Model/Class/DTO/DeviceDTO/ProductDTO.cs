using DeviceLib.Model.Class.Device;

namespace DeviceLib.Model.Class.DTO.DeviceDTO;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }

    public BrandDTO Brand { get; set; }
    public ICollection<ProductCharacteristicDTO> CharacteristicValues { get; set; }

}
