using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Authentication.Models;
using User_Authentication.Data;
using User_Authentication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace User_Authentication.Controllers
{ 
public class CustomersController : Controller
    {

        //Set a new private property on the controller to hold current session with db (Bangazon context)
       
        private ApplicationDbContext context;

  //Method: Purpose is make existing session with db (BangazonContext) available to other methods throughout the controller via this custom constructor, which accepts existing session as argument
        public CustomersController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        //Method: purpose is to create a new instance of the CreateCustomerViewModel and inject it into the Customer/Create view
           public IActionResult Create()
        {
            CreateCustomerViewModel model = new CreateCustomerViewModel(context);

            return View(model);
        }

        //Method: Overloaded Create method, the purpose of is to post a new customer to the database. Accepts an argument of type Customer, which is composed of the customer info entered into the Customer/Create view. This method also defines the newly created customer as the active customer and passes that active customer into the link below the customerId dropdown menu

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(ApplicationUser customer)
        {
            CreateCustomerViewModel model = new CreateCustomerViewModel(context); 

             if (ModelState.IsValid)
            {
            context.Add(customer);
            await context.SaveChangesAsync();
            Activate(customer.CustomerId);
            return RedirectToAction("Index", "Products");
            }
            return View(model);

        }
        //Method: Purpose is to create a new instance of the ActiveCustomer class based on the customerId selected in the dropdown method. Accepts an argument, passed in through route/URL of an integer (the selected customer's primary key/id)
        [HttpPost]
        public IActionResult Activate([FromRoute]int id)

        {
            //cycle through the existing customers table in the database and select the customerId that matches the argument
            var customer = context.ApplicationUser.SingleOrDefault(c => c.ApplicationUserId == id);
            
            if (customer == null)
            {
                return NotFound();
            }

            //create a new instance of the ActiveCustomer class and assign the selected customer to the .Customer property on that instance
            ActiveCustomer.instance.Customer = customer;

            return Json(customer);
        }
        //Method: Purpose is to return the Error view
        public IActionResult Error()
        {
            return View();
        }

namespace User_Authentication.Controllers
    {
        public class CustomersController : Controller
        {

            //Set a new private property on the controller to hold current session with db (Bangazon context)

            private ApplicationDbContext context;

            //Method: Purpose is make existing session with db (BangazonContext) available to other methods throughout the controller via this custom constructor, which accepts existing session as argument
            public CustomersController(ApplicationDbContext ctx)
            {
                context = ctx;
            }

            //Method: purpose is to create a new instance of the CreateCustomerViewModel and inject it into the Customer/Create view
            public IActionResult Create()
            {
                CreateCustomerViewModel model = new CreateCustomerViewModel(context);

                return View(model);
            }

            //Method: Overloaded Create method, the purpose of is to post a new customer to the database. Accepts an argument of type Customer, which is composed of the customer info entered into the Customer/Create view. This method also defines the newly created customer as the active customer and passes that active customer into the link below the customerId dropdown menu

            [HttpPost]
            [ValidateAntiForgeryToken]

            public async Task<IActionResult> Create(ApplicationUser customer)
            {
                CreateCustomerViewModel model = new CreateCustomerViewModel(context);

                if (ModelState.IsValid)
                {
                    context.Add(customer);
                    await context.SaveChangesAsync();
                    Activate(customer.CustomerId);
                    return RedirectToAction("Index", "Products");
                }
                return View(model);

            }
            //Method: Purpose is to create a new instance of the ActiveCustomer class based on the customerId selected in the dropdown method. Accepts an argument, passed in through route/URL of an integer (the selected customer's primary key/id)
            [HttpPost]
            public IActionResult Activate([FromRoute]int id)

            {
                //cycle through the existing customers table in the database and select the customerId that matches the argument
                var customer = context.Customer.SingleOrDefault(c => c.CustomerId == id);

                if (customer == null)
                {
                    return NotFound();
                }

                //create a new instance of the ActiveCustomer class and assign the selected customer to the .Customer property on that instance
                ActiveCustomer.instance.Customer = customer;

                return Json(customer);
            }
            //Method: Purpose is to return the Error view
            public IActionResult Error()
            {
                return View();
            }
        }
    }