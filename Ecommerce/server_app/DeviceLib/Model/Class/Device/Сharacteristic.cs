namespace DeviceLib.Model.Class.Device;

public class Сharacteristic
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; } 

    public CharacteristicType CharacteristicType { get; set; }
    public int CharacteristicTypeId { get; set; }


}
