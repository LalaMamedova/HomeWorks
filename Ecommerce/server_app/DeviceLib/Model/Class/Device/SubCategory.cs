using DeviceLib.Model.Class.DTO.DeviceDTO;
using server_app.Model.Class;

namespace DeviceLib.Model.Class.Device;

public class SubCategory
{
    public int Id { get; set; }
    public string Name { get; set; } //"UltraBook"

    public Category Category { get; set; }  //"Computer"
    public int CategoryId { get; set; }

    public ICollection<BrandAndSubCategory> Brands { get; set; }//"Acers,HP,DELL"
    public ICollection<CharacteristicType> CharacteristicsType { get; set; }//"Batery, Batery compacity"


}
