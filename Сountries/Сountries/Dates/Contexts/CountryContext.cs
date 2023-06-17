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
        public DbSet<HeadOfState> HeadOfStates { get; set; }
        public DbSet<HeadOfStatePosition> HeadOfStatePositions { get; set; }

        
       
        public CountryContext() {}

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
            var headofstate = modelBuilder.Entity<HeadOfState>();
            var headofstateposition = modelBuilder.Entity<HeadOfStatePosition>();

            country.HasKey(x => x.Id);
            country.Property(x =>x.CountryName).IsRequired();
            country.Property(x => x.Area).IsRequired();
            country.Property(x => x.CreateDate).IsRequired();
            country.Property(x => x.GDP).IsRequired();
            country.Property(x => x.MapImgLink).IsRequired();
            country.Property(x => x.Himn).IsRequired();
            //country.HasOne(c => c.Government).WithOne().HasForeignKey<Country>(c => c.GovermentTypeId);
            //country.HasOne(c => c.HeadOfStates).WithOne().HasForeignKey<Country>(c => c.CountryRulerId);

            country.HasOne(c => c.Government).WithMany().HasForeignKey(c => c.GovermentTypeId);
            country.HasOne(c => c.HeadOfStates).WithMany().HasForeignKey(c => c.CountryRulerId);


            goverments.HasKey(x => x.Id);
            goverments.Property(x => x.GovernmentForm).IsRequired();


            headofstateposition.HasKey(x => x.Id);
            headofstateposition.Property(x => x.Position).IsRequired();


            headofstate.HasKey(x => x.Id);
            headofstate.Property(x => x.Name).IsRequired();
            headofstate.Property(x => x.Surname).IsRequired();
            headofstate.Property(x => x.BirthDate).IsRequired();
            headofstate.HasOne(h => h.Position).WithMany().HasForeignKey(h => h.PositionId);
            //headofstate.HasOne(x => x.Position).WithOne().HasForeignKey<HeadOfState>(x => x.PositionId);
            headofstate.Ignore(x => x.FullName);
        }

    }
}
