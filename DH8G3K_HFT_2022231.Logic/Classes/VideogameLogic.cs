using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Models.Models.Helper_classes;
using DH8G3K_HFT_2022231.Repository;

namespace DH8G3K_HFT_2022231.Logic
{
    public class VideogameLogic : IVideogameLogic
    {
        IRepository<Videogame> repo;
        IRepository<Developer> developerrepo;
        IRepository<Franchise> franchiserepo;

        public VideogameLogic(IRepository<Videogame> repo, IRepository<Developer> developerrepo, IRepository<Franchise> franchiserepo)
        {
            this.repo = repo;
            this.developerrepo = developerrepo;
            this.franchiserepo = franchiserepo;
        }

        public void Create(Videogame item)
        {
            if (item.Title.Length < 2)
            {
                throw new ArgumentException("Title is too short.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Videogame Read(int id)
        {
            var videogame = this.repo.Read(id);
            if (videogame == null)
            {
                throw new ArgumentException("Videogame doesn't exist.");
            }
            return videogame;
        }

        public IQueryable<Videogame> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Videogame item)
        {
            this.repo.Update(item);
        }

        //non-crud methods
        public IEnumerable<VideogamesOfYearInfo> VideogamesOfYearX(int year)
        {
            var videogamesofyearx = from x in this.repo.ReadAll()
                                    where x.Release.Year == year
                                    select new VideogamesOfYearInfo()
                                    {
                                        Title = x.Title,
                                        Year = x.Release.Year
                                    };
            return videogamesofyearx;
        }

        public IEnumerable<VideogameDeveloperInfo> VideogamesWithDeveloperNames()
        {
            var info = from x in this.repo.ReadAll()
                       join y in this.franchiserepo.ReadAll() on x.FranchiseId equals y.FranchiseId
                       join z in this.developerrepo.ReadAll() on y.DeveloperId equals z.DeveloperId
                       select new VideogameDeveloperInfo()
                       {
                           Title = x.Title,
                           Developername = z.DeveloperName
                       };
            return info;
        }

        public IEnumerable<VideogameYearInfo> WhenWereVideogamesMade()
        {
            var info = from x in this.repo.ReadAll()
                       join y in this.repo.ReadAll() on x.VideogameId equals y.VideogameId
                       select new VideogameYearInfo()
                       {
                           Title = x.Title,
                           Release = y.Release.Year
                       };
            return info;
        }
        public BestRatedVideogameInfo TenOutOfTenVideogames()
        {
            var videogames = this.repo.ReadAll();
            var bestratedinfo = from x in this.repo.ReadAll()
                                    join y in videogames on x.VideogameId equals y.VideogameId
                                    where x.Rating.Equals(10)
                                    select new BestRatedVideogameInfo()
                                    {
                                        Title = x.Title,
                                        Rating = x.Rating
                                    };
            BestRatedVideogameInfo bestrated = bestratedinfo.First();
            return bestrated;
        }
    }
}
