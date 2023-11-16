using System.Text;

namespace DeviceLib.Model.Class.DTO.DeviceDTO;

public class CategoryDTO
{
 
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<SubCategoryDTO> SubCategories { get; set; }
}
