using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject
{
    public enum ViewComponents
    {
        LastItem
    }

    /// <summary>
    /// Pripravimo razred, ki razširi ViewComponent.
    /// Metoda InvokeAsync lahko prejme poljubno število parametrov
    /// in je odgovorna za prikaz komponente.
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-5.0
    /// </summary>
    [ViewComponent(Name = nameof(ViewComponents.LastItem))]
    public class LastItemViewComponent : ViewComponent
    {
        private readonly MvcDbContext _context;

        public LastItemViewComponent(MvcDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// InvokeAsync exposes a method which can be called from a view, 
        /// and it can take an arbitrary number of arguments.
        /// </summary>
        public async Task<IViewComponentResult> InvokeAsync(int counter)
        {
            var items = await GetItemsAsync();
            ViewBag.Counter = counter + 2019;
            return View(items);
        }

        private Task<Tile> GetItemsAsync()
        {
            return _context.Tiles.OrderByDescending(x => x.DateInserted).FirstOrDefaultAsync();
        }
    }
}
