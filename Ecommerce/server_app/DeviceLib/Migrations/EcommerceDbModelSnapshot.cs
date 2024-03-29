﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server_app.DatabaseContext;

#nullable disable

namespace DeviceLib.Migrations
{
    [DbContext(typeof(EcommerceDb))]
    partial class EcommerceDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeviceLib.Model.Class.Device.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.BrandAndSubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("BrandAndSubCategories");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.CharacteristicType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("CharacteristicTypes");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.ProductСharacteristicDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacteristicId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacteristicId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCharacteristics");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategorys");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.UserLikedProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LikedProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LikedProductId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLikededProducts");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.UserPurchasedProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PurchasedProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchasedProductId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPurchasedProducts");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.Сharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacteristicTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacteristicTypeId");

                    b.ToTable("Сharacteristics");
                });

            modelBuilder.Entity("server_app.Model.Class.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersDevicesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.BrandAndSubCategory", b =>
                {
                    b.HasOne("DeviceLib.Model.Class.Device.Brand", "Brand")
                        .WithMany("SubCategories")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeviceLib.Model.Class.Device.SubCategory", "SubCategory")
                        .WithMany("Brands")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.CharacteristicType", b =>
                {
                    b.HasOne("DeviceLib.Model.Class.Device.SubCategory", "SubCategory")
                        .WithMany("CharacteristicsType")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.Product", b =>
                {
                    b.HasOne("DeviceLib.Model.Class.Device.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.ProductСharacteristicDTO", b =>
                {
                    b.HasOne("DeviceLib.Model.Class.Device.Сharacteristic", "Characteristic")
                        .WithMany()
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeviceLib.Model.Class.Device.Product", "Product")
                        .WithMany("CharacteristicValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Characteristic");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.SubCategory", b =>
                {
                    b.HasOne("DeviceLib.Model.Class.Device.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.UserLikedProducts", b =>
                {
                    b.HasOne("DeviceLib.Model.Class.Device.Product", "LikedProduct")
                        .WithMany()
                        .HasForeignKey("LikedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server_app.Model.Class.User.User", "User")
                        .WithMany("UsersLikedDevices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LikedProduct");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.UserPurchasedProducts", b =>
                {
                    b.HasOne("DeviceLib.Model.Class.Device.Product", "PurchasedProduct")
                        .WithMany()
                        .HasForeignKey("PurchasedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server_app.Model.Class.User.User", "User")
                        .WithMany("UsersPurchasedDevices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchasedProduct");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.Сharacteristic", b =>
                {
                    b.HasOne("DeviceLib.Model.Class.Device.CharacteristicType", "CharacteristicType")
                        .WithMany("Characteristics")
                        .HasForeignKey("CharacteristicTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacteristicType");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.Brand", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.CharacteristicType", b =>
                {
                    b.Navigation("Characteristics");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.Product", b =>
                {
                    b.Navigation("CharacteristicValues");
                });

            modelBuilder.Entity("DeviceLib.Model.Class.Device.SubCategory", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("CharacteristicsType");
                });

            modelBuilder.Entity("server_app.Model.Class.User.User", b =>
                {
                    b.Navigation("UsersLikedDevices");

                    b.Navigation("UsersPurchasedDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
