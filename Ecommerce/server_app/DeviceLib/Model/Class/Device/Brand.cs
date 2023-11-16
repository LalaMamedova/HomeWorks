namespace DeviceLib.Model.Class.Device;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }//"Acer"

    public ICollection<BrandAndSubCategory> SubCategories { get; set; }//"UltraBook, NoteBook"
    public ICollection<Product> Products { get; set; }
}
