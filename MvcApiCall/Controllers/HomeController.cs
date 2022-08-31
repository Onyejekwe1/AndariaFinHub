using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcApiCall.Models;

namespace MvcApiCall.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var customers = Customer.GetCustomers();
            return View(customers.data);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Save(Customer customer)
        {
            
                var result = Customer.AddCustomer(customer);
                return RedirectToAction("Index");
        }
    }
}
