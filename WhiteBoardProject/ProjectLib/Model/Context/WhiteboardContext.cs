using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProjectLib.Model.Class;


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

            string connection = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = modelBuilder.Entity<User>();
            var usersArt = modelBuilder.Entity<UserArt>();

            users.HasKey(x => x.Id);
            users.Property(x=>x.Password).IsRequired();
            users.Property(x=>x.Username).IsRequired();
            users.Property(x => x.Email).IsRequired();
            //users.Ignore(x => x.IPEndPoint);
            users.HasMany(u => u.UserArts)
                 .WithOne(ua => ua.User)
                 .HasForeignKey(ua => ua.UserId);

            usersArt.HasKey(x => x.Id);
            usersArt.Property(x=>x.Width).HasDefaultValue(500);
            usersArt.Property(x => x.Height).HasDefaultValue(500);
            usersArt.Property(x => x.ArtName).IsRequired();
           

        }
    }
}
