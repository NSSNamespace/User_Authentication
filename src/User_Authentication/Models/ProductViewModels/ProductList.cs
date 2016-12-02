using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Models;
using User_Authentication.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace User_Authentication.Models.ProductViewModels
{
    public class ProductList
    {
        public IEnumerable<Product> Products { get; set; }
        public ProductList(ApplicationDbContext ctx)
        {
            var context = ctx;
        }
    }
} 