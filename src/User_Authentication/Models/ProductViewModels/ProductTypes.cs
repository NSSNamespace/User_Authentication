using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Models;
using User_Authentication.Data;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace User_Authentication.Models.ProductViewModels
{
    //Create ProductTypesViewModel that inherits from BaseViewModel 
    public class ProductTypesViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }

        public IEnumerable<ProductTypeSubCategory> ProductTypeSubCategories { get; set; }

        //Create a custom constructor that accepts BangazonContext as an argument and passes that context (session with db) up to the methods on BaseViewModel
        public ProductTypesViewModel(ApplicationDbContext ctx) { }
    }
}