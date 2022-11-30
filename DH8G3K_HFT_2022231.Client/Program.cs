using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTools;
using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Models.Models.Helper_classes;

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
                Console.WriteLine("Enter the properties of the franchise: ");
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
        static void Read(string entity)
        {
            if (entity == "Developer")
            {
                Console.WriteLine("Enter Id of the developer you want to get: ");
                int id = int.Parse(Console.ReadLine());
                Developer developer = Rest.Get<Developer>(id, "developer");
                Console.WriteLine($"{developer.DeveloperId}: {developer.DeveloperName}");
            }
            if (entity == "Franchise")
            {
                Console.WriteLine("Enter Id of the franchise you want to get: ");
                int id = int.Parse(Console.ReadLine());
                Franchise franchise = Rest.Get<Franchise>(id, "franchise");
                Console.WriteLine($"{franchise.FranchiseId}: {franchise.FranchiseName}");
            }
            if (entity == "Videogame")
            {
                Console.WriteLine("Enter Id of the videogame you want to get: ");
                int id = int.Parse(Console.ReadLine());
                Videogame videogame = Rest.Get<Videogame>(id, "videogame");
                Console.WriteLine($"{videogame.VideogameId}: {videogame.Title}");
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Developer")
            {
                Console.WriteLine("Enter id of the developer you want to update: ");
                int id = int.Parse(Console.ReadLine());
                Developer developer = Rest.Get<Developer>(id, "developer");
                Console.WriteLine("Enter new developers's properties: ");
                Console.WriteLine("Developer's new name: ");
                string newname = Console.ReadLine();
                developer.DeveloperName = newname;
                Rest.Put(developer, "developer");
            }
            if (entity == "Franchise")
            {
                Console.WriteLine("Enter id of the franchise you want to update: ");
                int id = int.Parse(Console.ReadLine());
                Franchise franchise = Rest.Get<Franchise>(id, "franchise");
                Console.WriteLine("Enter new franchise properties: ");
                Console.WriteLine("Franchise name: ");
                string newname = Console.ReadLine();
                franchise.FranchiseName = newname;
                Rest.Put(franchise, "franchise");
            }
            if (entity == "Videogame")
            {
                Console.WriteLine("Enter id of the videogame you want to update: ");
                int id = int.Parse(Console.ReadLine());
                Videogame videogame = Rest.Get<Videogame>(id, "videogame");
                Console.WriteLine("Enter new videogame properties: ");
                Console.WriteLine("Videogame title: ");
                string newtitle = Console.ReadLine();
                videogame.Title = newtitle;
                Rest.Put(videogame, "videogame");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Developer")
            {
                Console.WriteLine("Enter id of the developer you want to delete: ");
                int id = int.Parse(Console.ReadLine());
                Rest.Delete(id, "developer");
            }
            if (entity == "Franchise")
            {
                Console.WriteLine("Enter id of the franchise you want to delete: ");
                int id = int.Parse(Console.ReadLine());
                Rest.Delete(id, "franchise");
            }
            if (entity == "Videogame")
            {
                Console.WriteLine("Enter id of the videogame you want to delete: ");
                int id = int.Parse(Console.ReadLine());
                Rest.Delete(id, "videogame");
            }
        }

        //non-cruds

        //Videogame
        static void VideogamesWithDevelopernames()
        {
            List<VideogameDeveloperInfo> info = Rest.Get<VideogameDeveloperInfo>("stat/VideogamesWithDevelopernames");
            foreach (var item in info)
            {
                Console.WriteLine($"{item.Developername} made: \"{item.Title}\"");
            }
            Console.ReadLine();
        }

        static void WhenWereVideogamesMade()
        {
            List<VideogameYearInfo> info = Rest.Get<VideogameYearInfo>("stat/WhenWereVideogamesMade");
            foreach (var item in info)
            {
                Console.WriteLine($"\"{item.Title}\" was made in {item.Release}");
            }
            Console.ReadLine();
        }

        static void VideogamesOfYearX()
        {
            Console.WriteLine("Enter a year:");
            int year = int.Parse(Console.ReadLine());
            List<VideogamesOfYearInfo> info = Rest.Get<List<VideogamesOfYearInfo>>(year, "stat/VideogamesOfYearX");
            Console.WriteLine();
            Console.WriteLine($"Videogames made in {year}:");
            foreach (var item in info)
            {
                Console.WriteLine($"{item.Title}");
            }
            Console.ReadLine();
        }

        static void TenOutOfTenVideogames()
        {
            BestRatedVideogameInfo bestrated = Rest.GetSingle<BestRatedVideogameInfo>("stat/TenOutOfTenVideogames");
            Console.WriteLine("List of all videogames rated 10/10:");
            Console.WriteLine($"\"{bestrated.Title}\"");
            Console.ReadLine();
        }

        //Franchise
        static void FranchisesWithOnlyOneVideogame()
        {
            List<FranchiseInfo> info = Rest.Get<FranchiseInfo>("stat/FranchisesWithOnlyOneVideogame");
            foreach (var item in info)
            {
                Console.WriteLine("The " + item.FranchiseName + " has only one game.");
            }
            Console.ReadLine();
        }
        
        //Developer
        static void TotalNumberOfGamesByDeveloper()
        {
            Console.WriteLine("Choose a developer by id to see how many videogames they have:");
            int id = int.Parse(Console.ReadLine());
            int number = Rest.Get<int>(id, "stat/TotalNumberOfGamesByDeveloper");
            Developer developer = Rest.Get<Developer>(id, "developer");
            Console.WriteLine($"{developer.DeveloperName} has made {number} videogames overall.");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Rest = new RestService("http://localhost:55120/", "videogame");
        
            var videogameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Videogame"))
                .Add("Create", () => Create("Videogame"))
                .Add("Read", () => Read("Videogame"))
                .Add("Delete", () => Delete("Videogame"))
                .Add("Update", () => Update("Videogame"))
                .Add("Videogames of a specific year?", () => VideogamesOfYearX())
                .Add("List of all videogames rated 10/10?", () => TenOutOfTenVideogames())
                .Add("List of all videogames with their year of release:", () => WhenWereVideogamesMade())
                .Add("List of all videogames with their corresponding developers:", () => VideogamesWithDevelopernames())
                .Add("Exit", ConsoleMenu.Close);

            var developerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Developer"))
                .Add("Create", () => Create("Developer"))
                .Add("Read", () => Read("Developer"))
                .Add("Delete", () => Delete("Developer"))
                .Add("Update", () => Update("Developer"))
                .Add("Total number of games by developer?", () => TotalNumberOfGamesByDeveloper())
                .Add("Exit", ConsoleMenu.Close);

            var franchiseSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Franchise"))
                .Add("Create", () => Create("Franchise"))
                .Add("Read", () => Read("Franchise"))
                .Add("Delete", () => Delete("Franchise"))
                .Add("Update", () => Update("Franchise"))
                .Add("Franchises with only one game?", () => FranchisesWithOnlyOneVideogame())
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
