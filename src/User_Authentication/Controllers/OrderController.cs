using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using User_Authentication.Data;
using User_Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using User_Authentication.Services;
using Microsoft.Extensions.Logging;
using User_Authentication.Models.ProductViewModels;

//Authors: David Yunker & Elliott Williams

namespace User_Authentication.Controllers
{


    //Class: OrderController, which inherits from base class Controller 
    [Authorize]
    public class OrderController : Controller

    {
        private readonly UserManager<ApplicationUser> _userManager;

        //Set a private property of BangazonContext on the controller so that it has access to the database
        private ApplicationDbContext context;

        //Method: Custom contructor whose purpose is make existing session with db (BangazonContext) available to other methods throughout the controller, which accepts the existing database session as argument
        public OrderController(ApplicationDbContext ctx, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            context = ctx;
        }

        //Method: Purpose is to patch an order in database to reflect date completed when customer clicks confirm button
        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> Confirm()
        {
            var user = await GetCurrentUserAsync();
            var activeOrder = await context.Order.Where(o => o.DateCompleted == null && o.User == user).SingleOrDefaultAsync();
            activeOrder.DateCompleted = DateTime.Today;
            context.Update(activeOrder);
            await context.SaveChangesAsync();
            return View();
        }
        //Method: Purpose is to route the customer to the confirmation page once confirm button has been clicked and order date completed patch is completed
        [Authorize]
        public IActionResult Confirmation()
        {
            ViewData["Message"] = @"Order Processed! 
            Thank you for shopping at Bangazon!";
            return View();
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
        // Method: Purpose is to route the user to cart associated with the active customer

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cart()
        {
            var user = await GetCurrentUserAsync();
            var activeOrder = await context.Order.Where(o => o.DateCompleted == null && o.User == user).SingleOrDefaultAsync();
            Console.WriteLine(activeOrder);
            OrderViewModel model = new OrderViewModel(context, user);

            if (activeOrder == null)
            {
                var product = new Product() { Title = "" };
                model.SingleProducts = new List<Product>();
                model.SingleProducts.Add(product);

                var duplicateProduct = new Product() { Title = "" };
                model.DuplicateProducts = new List<Product>();
                model.DuplicateProducts.Add(duplicateProduct);
                return View(model);
            }
        

        List<LineItem> LineItemsOnActiveOrder = context.LineItem.Where(li => li.OrderId == activeOrder.OrderId).ToList();
            List<Product> ListOfProducts = new List<Product>();
            List<Product> SingleProducts = new List<Product>();
            List<Product> DuplicateProducts = new List<Product>();

            decimal CartTotal = 0;

            for (var i = 0; i < LineItemsOnActiveOrder.Count(); i++)
            {
                ListOfProducts.Add(context.Product.Where(p => p.ProductId == LineItemsOnActiveOrder[i].ProductId).SingleOrDefault());
                CartTotal += context.Product.Where(p => p.ProductId == LineItemsOnActiveOrder[i].ProductId).SingleOrDefault().Price;
            }

            model.CartTotal = CartTotal;
            model.Products = ListOfProducts;

            for (var i = 0; i < ListOfProducts.Count(); i++)
            {
                ListOfProducts[i].Quantity += 1;
            }

            for (var i = 0; i < ListOfProducts.Count(); i++)
            {
                if (ListOfProducts[i].Quantity > 1)
                {
                    DuplicateProducts.Add(ListOfProducts[i]);
                }
                else
                {
                    SingleProducts.Add(ListOfProducts[i]);
                }
            }
            model.SingleProducts = SingleProducts;

            for (var i = 0; i < DuplicateProducts.Count(); i++)
            {
                for (var j = 0; j < DuplicateProducts.Count(); j++)
                {
                    if (DuplicateProducts[i].ProductId == DuplicateProducts[j].ProductId)
                    {
                        DuplicateProducts.Remove(DuplicateProducts[i]);
                    }
                }
            }
            model.DuplicateProducts = DuplicateProducts;

            return View(model);

        }
    }
}