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
        private readonly MvcDbContext _context;

        public HomeController(ILogger<HomeController> logger, MvcDbContext context)
        {
            _logger = logger;
            _context = context;
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

        public IActionResult DatabaseTiles()
        {
            ViewBag.TimeController = DateTime.Now;
            // Create/retrieve flowers' context
            //var flowers = _context.Tiles.ToList();

            // Faster options:
            //var flowers = _context.Tiles.Select(x => new TileView() { TileID = x.TileID, Title = x.Title, Thumb = x.Thumb, Photo = x.Photo }).ToList();
            var flowers = _context.Tiles.Select(x => new TileViewPublic() { TileID = x.TileID, Title = x.Title, Thumb = x.Thumb }).ToList();

            return View(flowers);
        }

        /// <summary>
        /// Tole funkcijo kličemo z Ajaxom vsako sekundo 
        /// in na ta način posodabljamo našo komponento
        /// </summary>
        public IActionResult ReloadLastItem(int counter)
        {
            return ViewComponent(nameof(ViewComponents.LastItem), new { counter = counter });
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
