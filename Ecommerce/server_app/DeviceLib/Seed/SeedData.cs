using DeviceLib.Model.Class.Device;
using server_app.DatabaseContext;

namespace DeviceLib.Seed;

public class Seed
{
    private EcommerceDb db;
    public Seed(EcommerceDb dbContexnt)
    {
        db = dbContexnt;

        var category1 = new Category { Name = "Computers" };
        var category2 = new Category { Name = "Telefons" };
        var category3 = new Category { Name = "TVs" };
        var category4 = new Category { Name = "Appliances" };
        var category5 = new Category { Name = "Cameras" };



        var subcategory1 = new SubCategory { Name = "UltraBook", Category = category1, CategoryId = 1 };
        var subcategory2 = new SubCategory { Name = "Desktop PCs", Category = category1, CategoryId = 1 };
        var subcategory3 = new SubCategory { Name = "Laptops", Category = category1, CategoryId = 1 };
        var subcategory4 = new SubCategory { Name = "Refrigerators", Category = category4, CategoryId = 4 };
        var subcategory5 = new SubCategory { Name = "Digital Cameras", Category = category5, CategoryId = 5 };
        var subcategory6 = new SubCategory { Name = "Smartfones", Category = category2, CategoryId = 2 };

        var brand1 = new Brand
        {
            Name = "Acer",
            SubCategories = new List<BrandAndSubCategory>()
            {
                new BrandAndSubCategory
                {
                    SubCategory= subcategory1
                },
                     new BrandAndSubCategory
                {
                    SubCategory= subcategory3
                },
            }

        };
        var brand2 = new Brand
        {
            Name = "HP",
            SubCategories = new List<BrandAndSubCategory>()
            {
                new BrandAndSubCategory
                {
                    SubCategory = subcategory1
                },
                new BrandAndSubCategory
                {
                    SubCategory = subcategory2
                }
            }
        };
        var brand3 = new Brand
        {
            Name = "Dell",
            SubCategories = new List<BrandAndSubCategory>()
            {
                new BrandAndSubCategory
                {
                    SubCategory = subcategory1
                },
                new BrandAndSubCategory
                {
                    SubCategory = subcategory3
                },
            }
        };
        var brand4 = new Brand
        {
            Name = "Samsung",
            SubCategories = new List<BrandAndSubCategory>()
            {
                new BrandAndSubCategory
                {
                    SubCategory = subcategory6
                },
                 new BrandAndSubCategory
                {
                    SubCategory = subcategory5
                }
            }
        };

        var brand5 = new Brand
        {
            Name = "Sony",
            SubCategories = new List<BrandAndSubCategory>()
            {
                new BrandAndSubCategory
                {
                    SubCategory = subcategory5
                }
            }
        };

        var subCategoryBrands1 = new BrandAndSubCategory() { BrandId = 1, SubCategoryId = 2, Brand = brand1, SubCategory = subcategory2 };
        var subCategoryBrands2 = new BrandAndSubCategory() { BrandId = 1, SubCategoryId = 1, Brand = brand1, SubCategory = subcategory1 };
        var subCategoryBrands3 = new BrandAndSubCategory() { BrandId = 2, SubCategoryId = 3, Brand = brand2, SubCategory = subcategory3 };
        var subCategoryBrands4 = new BrandAndSubCategory() { BrandId = 5, SubCategoryId = 6, Brand = brand5, SubCategory = subcategory6 };

        var characteristicType1 = new CharacteristicType { Name = "Processors" };
        var characteristicType2 = new CharacteristicType { Name = "Screens" };
        var characteristicType3 = new CharacteristicType { Name = "Batteries" };
        var characteristicType4 = new CharacteristicType { Name = "Refrigerator Features" };
        var characteristicType5 = new CharacteristicType { Name = "Camera Specs" };

        var characteristic1 = new Сharacteristic { Name = "Core Count", Description = "Number of processor cores", CharacteristicType = characteristicType1, CharacteristicTypeId = 1 };
        var characteristic2 = new Сharacteristic { Name = "Screen Size", Description = "Display size in inches", CharacteristicType = characteristicType2, CharacteristicTypeId = 2 };
        var characteristic3 = new Сharacteristic { Name = "Battery Capacity", Description = "Battery capacity in mAh", CharacteristicType = characteristicType3, CharacteristicTypeId = 3 };
        var characteristic4 = new Сharacteristic { Name = "Refrigerator Capacity", Description = "Storage space in liters", CharacteristicType = characteristicType4, CharacteristicTypeId = 4 };
        var characteristic5 = new Сharacteristic { Name = "Megapixels", Description = "Camera resolution in megapixels", CharacteristicType = characteristicType5, CharacteristicTypeId = 5 };


        var product1 = new Product { Name = "Acer Aspire", Brand = brand1, BrandId = 1, Price = 1500.5f };
        var productCharacteristic1 = new ProductСharacteristic { Characteristic = characteristic1, Value = "8", Product = product1, CharacteristicId = 1, ProductId = 1 };

        var product2 = new Product { Name = "HP Envy", Brand = brand2, BrandId = 2, Price = 920.4f };
        var productCharacteristic2 = new ProductСharacteristic { Characteristic = characteristic1, Value = "6", Product = product2, CharacteristicId = 1, ProductId = 1 };

        var product3 = new Product { Name = "Dell XPS", Brand = brand3, BrandId = 3, Price = 1900.1f };
        var productCharacteristic3 = new ProductСharacteristic { Characteristic = characteristic1, Value = "10", Product = product3, CharacteristicId = 1, ProductId = 3 };

        var product4 = new Product { Name = "Samsung Galaxy", Brand = brand4, BrandId = 4, Price = 500f };
        var productCharacteristic4 = new ProductСharacteristic { Characteristic = characteristic3, Value = "6 inches", Product = product4, CharacteristicId = 3, ProductId = 4 };

        var product5 = new Product { Name = "Sony Alpha", Brand = brand5, BrandId = 5, Price = 990.99f };
        var productCharacteristic5 = new ProductСharacteristic { Characteristic = characteristic5, Value = "24 MP", Product = product5, CharacteristicId = 5, ProductId = 5 };

        if (db.ProductCharacteristics.Count() == 0)
        {
            //db.Categorys.AddRange(category1, category2,category3,category4);
            //db.SubCategorys.AddRange(subcategory1, subcategory2, subcategory3,subcategory4);
            //db.Brand.AddRange(brand1, brand2, brand3,brand4);
            //db.BrandAndSubCategories.AddRange(subCategoryBrands1, subCategoryBrands2, subCategoryBrands3);
            db.ProductCharacteristics.AddRange(productCharacteristic1, productCharacteristic2, productCharacteristic3, productCharacteristic4);
            db.SaveChanges();
        }
    }

}
