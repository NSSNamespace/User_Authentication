﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Models;
using User_Authentication.Data;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace User_Authentication.Models.ProductViewModels
{
    public class ProductDetail
    {
        public Product Product { get; set; }

        public ProductDetail(ApplicationDbContext ctx)
        {
            var context = ctx;
        }
    }
    
}
