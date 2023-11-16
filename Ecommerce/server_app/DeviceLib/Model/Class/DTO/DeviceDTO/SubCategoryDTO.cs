using DeviceLib.Model.Class.Device;

namespace DeviceLib.Model.Class.DTO.DeviceDTO;

public class SubCategoryDTO
{
    public string Name { get; set; }
    public ICollection<CharacteristicTypeDTO>? CharacteristicType { get; set; }
}