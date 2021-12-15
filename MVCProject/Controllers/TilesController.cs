using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class TilesController : Controller
    {
        private readonly MvcDbContext _context;

        public TilesController(MvcDbContext context)
        {
            _context = context;
        }

        // GET: Tiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiles.ToListAsync());
        }

        // GET: Tiles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tile = await _context.Tiles
                .FirstOrDefaultAsync(m => m.TileID == id);
            if (tile == null)
            {
                return NotFound();
            }

            return View(tile);
        }

        // GET: Tiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TileID,Title,Content,Description,DateInserted")] Tile tile)
        {
            if (ModelState.IsValid)
            {
                tile.TileID = Guid.NewGuid();
                _context.Add(tile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tile);
        }

        // GET: Tiles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tile = await _context.Tiles.FindAsync(id);
            if (tile == null)
            {
                return NotFound();
            }
            return View(tile);
        }

        // POST: Tiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TileID,Title,Content,Description,DateInserted")] Tile tile)
        {
            if (id != tile.TileID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TileExists(tile.TileID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tile);
        }

        // GET: Tiles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tile = await _context.Tiles
                .FirstOrDefaultAsync(m => m.TileID == id);
            if (tile == null)
            {
                return NotFound();
            }

            return View(tile);
        }

        // POST: Tiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tile = await _context.Tiles.FindAsync(id);
            _context.Tiles.Remove(tile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TileExists(Guid id)
        {
            return _context.Tiles.Any(e => e.TileID == id);
        }
    }
}
