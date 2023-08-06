using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Model.Context
{
    public class WhiteboardContext:DbContext
    {
        public DbSet<UserArt> UserArts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddJsonFile("appsetting.json", false, true);

            IConfiguration configuration = configurationBuilder.Build();
            string connection = configuration.GetConnectionString("Connection")!;
            optionsBuilder.UseSqlServer(connection);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = modelBuilder.Entity<User>();
            var usersArt = modelBuilder.Entity<UserArt>();

            users.HasKey(x => x.Id);
            users.Property(x=>x.Password).IsRequired();
            users.Property(x=>x.Username).IsRequired();
            users.Property(x => x.Email).IsRequired();
            users.HasOne(x => x.UserArts).WithMany().HasForeignKey(x => x.UserArt);

            usersArt.HasKey(x => x.Id);
            usersArt.Property(x => x.ArtName).IsRequired();

        }
    }
}
