using System;
using System.Collections.Generic;

namespace FiltrationOnEntity.Models.Class;

public partial class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public string? ImageLink { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
