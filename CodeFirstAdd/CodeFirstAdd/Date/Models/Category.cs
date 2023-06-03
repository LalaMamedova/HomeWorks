using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstAdd.Date.Models.Class;

public partial class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? CategoryName { get; set; }

    public string? ImageLink { get; set; }

}
