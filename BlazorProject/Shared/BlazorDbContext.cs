using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{    
    public class BlazorDbContext : DbContext
    {
        /// <summary>
        /// Pripravimo konstruktor, ki pošlje predniku možnosti
        /// </summary>
        public BlazorDbContext(DbContextOptions<BlazorDbContext> options) : base(options) { }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Subject> Subjects { get; set; }        
    }
}
