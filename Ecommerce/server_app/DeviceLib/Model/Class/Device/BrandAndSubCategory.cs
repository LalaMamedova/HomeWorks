namespace DeviceLib.Model.Class.Device;

public class BrandAndSubCategory
{
    public int Id { get; set; }

    public int BrandId { get; set; }
    public Brand Brand { get; set; }//"Dell"

    public int SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }//"NoteBook"
}
