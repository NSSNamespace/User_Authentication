using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using User_Authentication.Models;
using User_Authentication.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


//Class: OrderViewModel class
//Author: David Yunker
namespace User_Authentication.Models.ProductViewModels
{
    public class Order
    {
        public List<SelectListItem> PaymentTypeId { get; set; }
        public List<Product> Products { get; set; }
        public decimal CartTotal { get; set; }
        private ApplicationDbContext context;
      //  private ActiveCustomer singleton = ActiveCustomer.instance;

        public List<Product> SingleProducts { get; set; }

        public List<Product> DuplicateProducts { get; set; }


        //Method Name: OrderViewModel custom contructor
        //Purpose of the Method: Upon construction this should take the context and send a list of select items of the type PaymentType to the View. They should be the paymentTypes of the active customer.
        //Arguments in Method: BangazonWebContext
        public Order (ApplicationDbContext ctx)
        {
      //      var customer = ActiveCustomer.instance.Customer;
            var context = ctx;
            this.PaymentTypeId = context.PaymentType
                .Where(pt => pt.ApplicationUserId == applicationuser.CustomerId)
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


  
