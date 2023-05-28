using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiltrationOnEntity.Models.Class;

public partial class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? ImageLink { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }


    public override string ToString()
    {
        return ProductName ;
    }
}
