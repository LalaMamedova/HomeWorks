using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сountries.Dates.Models;

namespace Сountries.Dates.Contexts
{
    public class CountryContext:DbContext
    {
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Government> Governments { get; set; }


        public CountryContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddJsonFile("appsetting.json",false,true);
            IConfiguration configuration = configurationBuilder.Build();

            string connection = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var country = modelBuilder.Entity<Country>();
            var goverments = modelBuilder.Entity<Government>();

            country.HasKey(x => x.Id);
            country.Property(x =>x.CountryName).IsRequired();
            country.Property(x => x.Area).IsRequired();
            country.Property(x => x.CreateDate).IsRequired();
            country.Property(x => x.GDP).IsRequired();
            country.Property(x => x.MapImgLink).IsRequired();
            country.HasOne(c => c.Government).WithOne().HasForeignKey<Government>(c => c.Id);


            goverments.HasKey(x => x.Id);
            goverments.Property(x => x.GovernmentForm).IsRequired();

        }
    }
}
