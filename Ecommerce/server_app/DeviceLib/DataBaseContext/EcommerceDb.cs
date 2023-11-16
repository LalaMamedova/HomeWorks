using DeviceLib.Model.Class.Device;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server_app.Model.Class.User;

namespace server_app.DatabaseContext;

public class EcommerceDb : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categorys { get; set; }
    public DbSet<SubCategory> SubCategorys { get; set; }
    public DbSet<Сharacteristic> Сharacteristics { get; set; }
    public DbSet<CharacteristicType> CharacteristicTypes { get; set; }
    public DbSet<ProductСharacteristic> ProductCharacteristics { get; set; }
    public DbSet<UserPurchasedProducts> UserPurchasedProducts { get; set; }
    public DbSet<BrandAndSubCategory> BrandAndSubCategories { get; set; }
    public DbSet<UserLikedProducts> UserLikededProducts { get; set; }

    public EcommerceDb(DbContextOptions<EcommerceDb> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<EcommerceDb>().Build();
        var connectionString = config["ConnectionString"];

        optionsBuilder.UseSqlServer(connectionString);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var device = modelBuilder.Entity<Product>();
        var deviceBrand = modelBuilder.Entity<Brand>();
        var subCategory = modelBuilder.Entity<SubCategory>();
        var deviceCategory = modelBuilder.Entity<Category>();
        var charType = modelBuilder.Entity<CharacteristicType>();
        var characteristics = modelBuilder.Entity<Сharacteristic>();
        var productChar = modelBuilder.Entity<ProductСharacteristic>();
        var usersLikedProducts = modelBuilder.Entity<UserLikedProducts>();
        var usersPurchasedProducts = modelBuilder.Entity<UserPurchasedProducts>();
        var brandAndSubCategory = modelBuilder.Entity<BrandAndSubCategory>();

        modelBuilder.Entity<User>().HasKey(c => c.Id);
        modelBuilder.Entity<User>(e =>
        {
            e.Property(e => e.Email).IsRequired(false);
            e.Property(e => e.Password).IsRequired(false);
        });

        ////**********************************************************************

        productChar.HasKey(c => c.Id);
        
        ////**********************************************************************
        deviceBrand.HasKey(c => c.Id);
        deviceCategory.Property(c => c.Name).IsRequired();

        deviceBrand
            .HasMany(c => c.Products)
            .WithOne(c=>c.Brand)
            .HasForeignKey(c => c.BrandId);


        ////**********************************************************************
        subCategory.HasKey(c => c.Id);
        subCategory.Property(c => c.Name).IsRequired();

        ////**********************************************************************

        brandAndSubCategory.HasKey(c => c.Id);

        brandAndSubCategory
            .HasOne(c=>c.Brand)
            .WithMany(c=>c.SubCategories)
            .HasForeignKey(c => c.BrandId);

        brandAndSubCategory
           .HasOne(c => c.SubCategory)
           .WithMany(c => c.Brands)
           .HasForeignKey(c => c.SubCategoryId);

        ////**********************************************************************

        deviceCategory.HasKey(d => d.Id);
        deviceCategory.Property(d => d.Name).IsRequired();

        deviceCategory
            .HasMany(c => c.SubCategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);

        ////**********************************************************************
   
        device.HasKey(d => d.Id);
        device.Property(d => d.Name).IsRequired();
        device.Property(d => d.Price).IsRequired();

        device
            .HasMany(x => x.CharacteristicValues)
            .WithOne(db => db.Product)
            .HasForeignKey(x => x.ProductId);

        ////**********************************************************************

        charType.HasKey(c => c.Id);
        charType.Property(c => c.Name).IsRequired();

        charType
            .HasMany(c=>c.Characteristics)
            .WithOne(c=>c.CharacteristicType)
            .HasForeignKey(c => c.CharacteristicTypeId);

        charType
            .HasOne(c => c.SubCategory)
            .WithMany(c => c.CharacteristicsType)
            .HasForeignKey(c => c.SubCategoryId);

        ////**********************************************************************

        characteristics.HasKey(c => c.Id);
        characteristics.Property(c => c.Name).IsRequired();
        characteristics.Property(c => c.Description).IsRequired(false);

 
 
        ////**********************************************************************

        usersLikedProducts.HasKey(c => c.Id);
        usersLikedProducts
            .HasOne(ud => ud.User)
            .WithMany(u => u.UsersLikedDevices)
            .HasForeignKey(u => u.UserId);

        ////**********************************************************************

        usersPurchasedProducts.HasKey(c => c.Id);
        usersPurchasedProducts
            .HasOne(ud => ud.User)
            .WithMany(u => u.UsersPurchasedDevices)
            .HasForeignKey(u => u.UserId);


    }
}
