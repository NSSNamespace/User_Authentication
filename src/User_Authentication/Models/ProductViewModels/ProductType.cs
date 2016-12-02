using System.Collections.Generic;
using System.Linq;
using User_Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

/*
Author: Jammy Laird
*/

namespace User_Authentication.Models.ProductViewModels
{
    //Create ProductTypeViewModel that inherits from BaseViewModel
    public class ProductTypeViewModel
    {
        public IEnumerable<ProductType> ProductTypes { get; set; }
        //Create a custom constructor that accepts BangazonContext as an argument and passes that context (session with db) up to the methods on BaseViewModel
        public ProductTypeViewModel(ApplicationDbContext ctx)
        { }
    }
}