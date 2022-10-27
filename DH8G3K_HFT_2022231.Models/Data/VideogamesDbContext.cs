using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Models.Data
{
    class VideogamesDbContext : DbContext
    {
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public VideogamesDbContext()
        {
            this.Database.EnsureCreated();
        }
    }
}
