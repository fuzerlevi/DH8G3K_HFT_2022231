using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTools;
using DH8G3K_HFT_2022231.Models;

namespace DH8G3K_HFT_2022231.Client
{
    class Program
    {
        static RestService Rest;
        static void List(string entity)
        {
            if (entity == "Videogame")
            {
                List<Videogame> items = Rest.Get<Videogame>("Videogame");
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.VideogameId + "\t" + item.Title);
                }
            }
            if(entity == "Developer")
            {
                List<Developer> items = Rest.Get<Developer>("Developer");
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.DeveloperId + "\t" + item.DeveloperName);
                }
            }
            if (entity == "Franchise")
            {
                List<Franchise> items = Rest.Get<Franchise>("Franchise");
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
            if (entity == "Franchise")
            {
                Console.WriteLine("Enter the properties of the artist: ");
                Console.Write("Enter the nem of the franchise: ");
                string name = Console.ReadLine();
                Console.Write("Enter the number of games the franchise has: ");
                int numberofgames = int.Parse(Console.ReadLine());
                Console.Write("Enter the developer Id of the franchise: ");
                int developerid = int.Parse(Console.ReadLine());
                Rest.Post(new Franchise() { FranchiseName = name, NumberOfGames = numberofgames, DeveloperId = developerid }, "franchise");
            }
            if (entity == "Developer")
            {
                Console.WriteLine("Enter the properties of the developer: ");
                Console.Write("Enter the name of the developer: ");
                string name = Console.ReadLine();
                
                Rest.Post(new Developer() { DeveloperName = name }, "developer");
            }
            if (entity == "Videogame")
            {
                Console.WriteLine("Enter the properties of the videogame: ");
                Console.Write("Enter the title: ");
                string title = Console.ReadLine();
                Console.Write("Enter the rating of the videogame: ");
                double rating = double.Parse(Console.ReadLine());
                Console.Write("Enter the release date of the videogame: ");
                DateTime release = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter the franchise Id of the videogame: ");
                int franchiseid = int.Parse(Console.ReadLine());
                Rest.Post(new Videogame() { Title = title, Rating = rating}, "videogame");
            }
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
