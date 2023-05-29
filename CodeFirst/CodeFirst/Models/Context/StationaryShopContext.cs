using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models.Context;

public partial class StationaryShopContext : DbContext
{
    public DbSet<StationeryCategory> Categories { get; set; }
    public DbSet<Stationery> Products { get; set; }
    public DbSet<Sales> Sales { get; set; }

    public StationaryShopContext()
    {
       
    }

    public StationaryShopContext(DbContextOptions<StationaryShopContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Data Source=HP;Initial Catalog=StationaryShop;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True;Encrypt=True;");


}
