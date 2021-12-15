using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Controllers
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
            return View();
        }

        public IActionResult Tiles()
        {
            return View();
        }

        public IActionResult DynamicTiles()
        {
            List<Flower> lstTiles = new List<Flower>() 
            { 
                new Flower(){Name="Tulipan", Color="black" },
                new Flower(){Name="Vrtnica", Color="yellow" },
                new Flower(){Name="Vijolica", Color="violet" },
                new Flower(){Name="Mak", Color="red" },
                new Flower(){Name="Trobentica", Color="orange" }
            };

            ViewBag.UserName = "Borut";

            return View(lstTiles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public struct Flower
    {
        public string Name { get; set; }

        public string Color { get; set; }
    }
}
