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

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                AttachDbFilename=|DataDirectory|\videogames.mdf;Integrated Security=True;MultipleActiveResultSets=true";

                builder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Videogame>(videogame => videogame
                    .HasOne<Franchise>()
                    .WithMany()
                    .HasForeignKey(videogame => videogame.FranchiseId)
                    .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Franchise>(franchise => franchise
                    .HasOne<Developer>()
                    .WithMany()
                    .HasForeignKey(videogame => videogame.DeveloperId)
                    .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Videogame>().HasData(new Videogame[]
            {
                new Videogame(),
            });

            modelBuilder.Entity<Developer>().HasData(new Developer[]
            {
                new Developer(),
            });

            modelBuilder.Entity<Franchise>().HasData(new Franchise[]
            {
                new Franchise(),
            });
        }
    }
}
