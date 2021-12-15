using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject
{
    public class MvcDbContext : DbContext
    {
        /// <summary>
        /// Pripravimo konstruktor, ki pošlje predniku možnosti
        /// </summary>
        public MvcDbContext(DbContextOptions<MvcDbContext> options) : base(options) { }

        public DbSet<Tile> Tiles { get; set; }
    }
}
