using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Models;
using User_Authentication.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace User_Authentication.Models.ProductViewModels
{
    public class CreateProduct
    {
        public Product Product { get; set; }
        public List<SelectListItem> ProductTypeId { get; set; }
        public List<SelectListItem> ProductTypeSubCategoryId { get; set; }
        public CreateProduct(ApplicationDbContext ctx)
        {

            this.ProductTypeId = ctx.ProductType
                                    .OrderBy(l => l.Label)
                                    .AsEnumerable()
                                    .Select(li => new SelectListItem
                                    {
                                        Text = li.Label,
                                        Value = li.ProductTypeId.ToString()
                                    }).ToList();

            this.ProductTypeId.Insert(0, new SelectListItem
            {
                Text = "Choose category...",
                Value = "0"
            });
        }
    }
}
