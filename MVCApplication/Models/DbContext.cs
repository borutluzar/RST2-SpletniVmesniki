using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplication.Models
{
    public class WebAppContext : DbContext
    {
        /// <summary>
        /// Pripravimo konstruktor, ki pošlje predniku možnosti
        /// </summary>
        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options) { }

        public DbSet<Tile> Tiles { get; set; }
    }
}
