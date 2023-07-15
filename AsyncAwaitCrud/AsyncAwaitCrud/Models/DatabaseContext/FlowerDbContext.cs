using AsyncAwaitCrud.Models.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitCrud.Models.DatabaseContext
{
    public class FlowerDbContext : DbContext
    {
        public DbSet<Flower> Flowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddJsonFile("appsetting.json", false, true);
            IConfiguration configuration = configurationBuilder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var flower = modelBuilder.Entity<Flower>();

            flower.HasKey(x => x.Id);
            flower.Property(x => x.Name).IsRequired();
            flower.Property(x => x.Price).IsRequired();
            flower.Property(x => x.Price).HasColumnName("Price");

            flower.Property(x => x.Price).HasColumnType("smallmoney");
            flower.Property(x => x.Color).IsRequired();

        }

    }
}
