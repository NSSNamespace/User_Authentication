using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Models;
using User_Authentication.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;


//Class: OrderViewModel class
//Author: David Yunker
namespace User_Authentication.Models.ProductViewModels
{
    public class OrderViewModel
    {
        public List<SelectListItem> PaymentTypeId { get; set; }
        public List<Product> Products { get; set; }
        public decimal CartTotal { get; set; }
        private ApplicationDbContext context;

        public List<Product> SingleProducts { get; set; }

        public List<Product> DuplicateProducts { get; set; }


        //Method Name: OrderViewModel custom contructor
        //Purpose of the Method: Upon construction this should take the context and send a list of select items of the type PaymentType to the View. They should be the paymentTypes of the active customer.
        //Arguments in Method: BangazonWebContext
        public OrderViewModel (ApplicationDbContext ctx, ApplicationUser user)
        {
            var context = ctx;
            var User = user;
            this.PaymentTypeId = context.PaymentType
                .Where(pt => pt.User == User)
                .AsEnumerable()
                .Select(li => new SelectListItem
                {
                    Text = li.Description,
                    Value = li.PaymentTypeId.ToString()
                }).ToList();

            this.PaymentTypeId.Insert(0, new SelectListItem
            {
                Text = "Choose Payment Type",
                Value = ""
            });
        }
    }
}


  
