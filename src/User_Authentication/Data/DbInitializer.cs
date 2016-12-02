using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace User_Authentication.Data
{
    //Class: DbInitializer
    //Purpose: Checks to see if the database has product types and product subtypes; if it doesn't, the database will be seeded.
    public class DbInitializer
    {
        //Method: The initialize method creates a scoped variable "context," which represents a session with the database. If there are any product types currently in the database, then it will not be seeded.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any products types.
                if (context.ProductType.Any())
                {
                    return;
                }

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
            }
        }
    }
}
