using System;
using System.Linq;
using ConsoleTools;
using DH8G3K_HFT_2022231.Logic;
using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Repository;
using DH8G3K_HFT_2022231.Repository.Database;

namespace DH8G3K_HFT_2022231.Client
{
    class Program
    {
        static VideogameLogic videogameLogic;
        static DeveloperLogic developerLogic;
        static FranchiseLogic franchiseLogic;

        static void List(string entity)
        {
            if (entity == "Videogame")
            {
                var items = videogameLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.VideogameId + "\t" + item.Title);
                }
            }
            else if(entity == "Developer")
            {
                var items = developerLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.DeveloperId + "\t" + item.DeveloperName);
                }
            }
            else if (entity == "Franchise")
            {
                var items = franchiseLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.FranchiseId + "\t" + item.FranchiseName);
                }
            }
            Console.ReadLine();
        }
        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            var ctx = new VideogameDbContext();

            var videogameRepo = new VideogameRepository(ctx);
            var developerRepo = new DeveloperRepository(ctx);
            var franchiseRepo = new FranchiseRepository(ctx);

            videogameLogic = new VideogameLogic(videogameRepo);
            developerLogic = new DeveloperLogic(developerRepo);
            franchiseLogic = new FranchiseLogic(franchiseRepo);

            var videogameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Videogame"))
                .Add("Create", () => Create("Videogame"))
                .Add("Delete", () => Delete("Videogame"))
                .Add("Update", () => Update("Videogame"))
                .Add("Exit", ConsoleMenu.Close);

            var developerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Developer"))
                .Add("Create", () => Create("Developer"))
                .Add("Delete", () => Delete("Developer"))
                .Add("Update", () => Update("Developer"))
                .Add("Exit", ConsoleMenu.Close);

            var franchiseSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Franchise"))
                .Add("Create", () => Create("Franchise"))
                .Add("Delete", () => Delete("Franchise"))
                .Add("Update", () => Update("Franchise"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Videogames", () => videogameSubMenu.Show())
                .Add("Developers", () => developerSubMenu.Show())
                .Add("Franchises", () => franchiseSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
