using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstAdd.Date.Models.Class;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public string? ImageLink { get; set; }

    [Required]
    public string ProductName { get; set; } 

    [Required]
    public decimal Price { get; set; } 
    [Required]
    public int Count { get; set; }


    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; } 

    public int Size { get; set; } 



    public override string ToString()
    {
        return ProductName ;
    }
}
