namespace DeviceLib.Model.Class.Device;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<SubCategory> SubCategories { get; set; }

}
