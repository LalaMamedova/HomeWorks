namespace DeviceLib.Model.Class.Device;

public class ProductСharacteristic
{
    public int Id { get; set; }

    public int CharacteristicId { get; set; }
    public Сharacteristic Characteristic { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public string Value { get; set; }

}
