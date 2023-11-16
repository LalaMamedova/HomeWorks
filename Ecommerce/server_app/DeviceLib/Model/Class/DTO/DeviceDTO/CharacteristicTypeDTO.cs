using System.Reflection.PortableExecutable;

namespace DeviceLib.Model.Class.DTO.DeviceDTO
{
    public class CharacteristicTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<СharacteristicDTO> Сharacteristic { get; set; }
    }
}
