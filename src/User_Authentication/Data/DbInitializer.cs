 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace User_Authentication.Data
{
    public class DbInitializer
    {
        //Method: The initialize method creates a scoped variable "context," which represents a session with the database. If there are any products currently in the database, then it will not be seeded.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any products.
                if (context.Product.Any())
                {
                    return;
                }

                var ApplicationUsers = new ApplicationUser[]
                {
                  new ApplicationUser {
                      FirstName = "Carson",
                      LastName = "Alexander",
                      StreetAddress = "100 Infinity Way"
                  },
                  new ApplicationUser {
                      FirstName = "Steve",
                      LastName = "Brownlee",
                      StreetAddress = "92 Main Street"
                  },
                  new ApplicationUser {
                      FirstName = "Tractor",
                      LastName = "Ryan",
                      StreetAddress = "1666 Catalina Blvd"
                  }
                };

                foreach (ApplicationUser c in ApplicationUsers)
                {
                    context.ApplicationUser.Add(c);
                }
                context.SaveChanges();


                var productTypes = new ProductType[]
                {
                  new ProductType {
                      Label = "Electronics"
                  },
                  new ProductType {
                      Label = "Appliances"
                  },
                  new ProductType {
                      Label = "Housewares"
                  },
                };

                foreach (ProductType i in productTypes)
                {
                    context.ProductType.Add(i);
                }
                context.SaveChanges();

                var productTypesSubCategories = new ProductTypeSubCategory[]
                {
                  new ProductTypeSubCategory {
                      Name = "Indoor Electronics",
                      ProductTypeId = 1
                  },


                 new ProductTypeSubCategory {
                      Name = "Outdoor Electronics",
                      ProductTypeId = 1
                  },

                   new ProductTypeSubCategory {
                      Name = "Office Appliances",
                      ProductTypeId = 2
                   },

                 new ProductTypeSubCategory {
                      Name = "Miscellaneous Appliances",
                      ProductTypeId = 2
                  },

                    new ProductTypeSubCategory {
                      Name = "Bed and Bath Housewares",
                      ProductTypeId = 3
                    },

                 new ProductTypeSubCategory {
                      Name = "Kitchen Housewares",
                      ProductTypeId = 3
                  },
                };

                foreach (ProductTypeSubCategory i in productTypesSubCategories)
                {
                    context.ProductTypeSubCategory.Add(i);
                }
                context.SaveChanges();


                var products = new Product[]
                {
                  new Product {
                      Description = "Colorful throw pillows to liven up your home",
                      ProductTypeId = productTypes.Single(s => s.Label == "Housewares").ProductTypeId,
                      ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Bed and Bath Housewares").ProductTypeSubCategoryId,
                      Title = "Throw Pillow",
                      Price = 7.49M,
                     // ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Tractor").ApplicationUserId
                  },
                  new Product {
                      Description = "A 2012 iPod Shuffle. Headphones are included. 16G capacity.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "iPod Shuffle",
                      Price = 18.00M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                  new Product {
                      Description = "Stainless steel refrigerator. Three years old. Minor scratches.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Appliances").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Miscellaneous Appliances").ProductTypeSubCategoryId,
                      Title = "Samsung refrigerator",
                      Price = 500.00M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Carson").Id
                  },
                    new Product {
                      Description = "New 13-inch Macbook Pro, mid 2012 model.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Macbook Pro",
                      ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Price = 1099.00M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Bose® - SoundTrue® Around-Ear Headphones II (iOS) - Charcoal Black.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Bose Headphones",
                      ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Price = 129.99M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Mechanical gaming keyboard, all keys individually backlit and customizable.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                              ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Logitech G910 keyboard",
                      Price = 139.00M,
                     // ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Optical gaming mouse, customizeble weight and lighting.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Logitech G502 mouse",
                      Price = 89.99M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "14-inch full HD IPS display, aluminum body chromebook.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Acer Chromebook 14",
                      Price = 299.99M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "HP Pavilion 21.5-Inch IPS LED HDMI VGA Monitor.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "HP Flatscreen monitor",
                      Price = 99.99M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Cooler Master HAF 932 Advanced Full Tower Case with SuperSpeed USB 3.0",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Cooler Master computer tower",
                      Price = 160.00M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "eagate Expansion 1TB Portable External Hard Drive USB 3.0",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Seagate external hard drive",
                      Price = 54.99M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Anker PowerLine Micro USB (3ft) - Durable Charging Cable.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Anker charging cable",
                      Price = 4.99M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                  new Product {
                      Description = "Anker 40W 4-Port USB Wall Charger PowerPort 4, Multi-Port USB Charger with Foldable Plug",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Anker wall charger",
                      Price = 25.99M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Tractor").ApplicationUserId
                  },
                  new Product {
                      Description = "Hoover Linx BH50010 Cordless Stick Vacuum Cleaner",
                      ProductTypeId = productTypes.Single(s => s.Label == "Housewares").ProductTypeId,
                      ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Kitchen Housewares").ProductTypeSubCategoryId,
                      Title = "Hoover vacuum",
                      Price = 95.30M,
                     // ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                  new Product {
                      Description = "KRUPS EA8808 2-IN-1 Touch Cappuccino Fully Automatic Espresso Machine, 57-Ounce, Black",
                      ProductTypeId = productTypes.Single(s => s.Label == "Appliances").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Office Appliances").ProductTypeSubCategoryId,
                      Title = "Cappuccino and espresso machine",
                      Price = 1299.00M,
                    //  ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Carson").ApplicationUserId
                  },
                    new Product {
                      Description = "Ultrasonic Cool Mist Humidifier - Premium Humidifying Unit with Whisper-quiet Operation, Automatic Shut-off, and Night Light Function.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Ultrasonic humidifier",
                      Price = 49.99M,
                     // ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Apple Watch Sport, Space Grey Aluminum Case/Black Band, 42mm.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Apple smartwatch",
                      Price = 199.99M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Cambridge SoundWorks OontZ Angle 3 Next Generation Ultra Portable Wireless Bluetooth Speaker",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Bluetooth speaker",
                      Price = 27.99M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Anker PowerCore 20100 - Ultra High Capacity Power Bank",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Anker power bank",
                      Price = 39.99M,
                      ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Belkin 6-Outlet Power Strip Surge Protector with 2-Foot Power Cord, 200 Joules (2-Pack)",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Belkin power strip",
                      Price = 9.37M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "SanDisk Cruzer CZ36 64GB USB 2.0 Flash Drive",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "SanDisk flash drive",
                      Price = 19.45M,
                     // ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "EVGA GeForce GTX 750 Ti FTW GDDR5 Graphics Card",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "EVGA graphics card",
                      Price = 132.37M,
                      //ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Intel Core i5 6600K 3.90 GHz Quad Core Skylake Desktop Processor",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Intel Processor",
                      Price = 237.39M,
                    //  ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "Corsair Vengeance Pro 16GB (2x8GB) DDR3 2400MHz PC3 19200 Desktop RAM, Red",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Desktop RAM",
                      Price = 96.41M,
                     // ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  },
                    new Product {
                      Description = "ASUS Z170-A ATX DDR4 Motherboard",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                         ProductTypeSubCategoryId = productTypesSubCategories.Single(s => s.Name == "Indoor Electronics").ProductTypeSubCategoryId,
                      Title = "Asus motherboard",
                      Price = 149.98M,
                  //    ApplicationUserId = ApplicationUsers.Single(s => s.FirstName == "Steve").ApplicationUserId
                  }
                };

                foreach (Product i in products)
                {
                    context.Product.Add(i);
                }
                context.SaveChanges();
            }
        }
    }
}
