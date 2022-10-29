using DH8G3K_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Repository.Data
{
    public class VideogameDbContext : DbContext
    {
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public VideogameDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\videogame.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Videogame>(videogame => videogame
                    .HasOne(videogame => videogame.Franchise)
                    .WithMany(Franchise => Franchise.Videogames)
                    .HasForeignKey(videogame => videogame.FranchiseId)
                    .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Franchise>(franchise => franchise
                    .HasOne(franchise => franchise.Developer)
                    .WithMany(Developer => Developer.Franchises)
                    .HasForeignKey(videogame => videogame.DeveloperId)
                    .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Videogame>().HasData(new Videogame[]
            {
                new Videogame("1#1#Dark Souls: Prepare To Die Edition#2011*09*22#9"),
                new Videogame("2#1#Dark Souls: REMASTERED#2018*05*24#9,5"),
                new Videogame("3#1#Dark Souls II#2014*03*11#9"),
                new Videogame("4#1#Dark Souls II: Scholar of the First Sin#2015*04*01#9"),
                new Videogame("5#1#Dark Souls III#2016*03*24#9,5"),

                new Videogame("6#2#Elden Ring#2022*02*25#9,7"),

                new Videogame("7#3#Overwatch#2016*05*24#10"),
                new Videogame("8#3#Overwatch 2#2022*10*04#8"),
            });

            modelBuilder.Entity<Developer>().HasData(new Developer[]
            {
                new Developer("1#FromSoftware"),
                new Developer("2#Blizzard Entertainment"),
            });

            modelBuilder.Entity<Franchise>().HasData(new Franchise[]
            {
                new Franchise("1#1#Dark Souls Franchise#5"),
                new Franchise("2#1#Elden Ring Franchise#1"),
                new Franchise("3#2#Overwatch Franchise#2"),
            });
        }
    }
}
