using Feestgangers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

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
            var rows = Database.DatabaseConnector.GetRows("Select * from festival");

            List<string> names = new List<string>();

            foreach (var row in rows)
            {

                names.Add(row["naam"].ToString());
            }
            
            return View(names);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult contact()
        {
            return View();
        }

        [HttpPost]

        public IActionResult contact(Person person)
        {
            ViewData["firstname"] = person.firstname;
            ViewData["lastname"] = person.lastname;

            return View(person);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
