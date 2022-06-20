using Feestgangers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using MySql.Data;
using Feestgangers.Database;
using System;

namespace Feestgangers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            var products =GetAllProducts();

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("contact")]

        public IActionResult Contact()
        {
            return View();
        }

        [Route("Succes")]
        public IActionResult Succes()
        {
            return View();
        }

        [Route("contact")]
        [HttpPost]

        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
                return Redirect("/Succes");

            return View(person);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Product> GetAllProducts()
        {
            var rows = DatabaseConnector.GetRows("select * from product");

            List<Product> products = new List<Product>();

            foreach (var row in rows)
            {

                Product p = new Product();
                p.festival = row["festival"].ToString();
                p.artiesten = row["artiesten"].ToString();
                p.Planning = Convert.ToInt32(row["Planning"]);

                products.Add(p);

            }

            return products;

        }

    }
}
