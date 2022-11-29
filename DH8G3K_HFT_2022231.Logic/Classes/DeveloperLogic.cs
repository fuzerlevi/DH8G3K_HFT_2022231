using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Logic
{
    public class DeveloperLogic : IDeveloperLogic
    {
        IRepository<Developer> repo;
        IRepository<Videogame> videogamerepo;
        IRepository<Franchise> franchiserepo;

        public DeveloperLogic(IRepository<Developer> repo, IRepository<Videogame> videogamerepo, IRepository<Franchise> franchiserepo)
        {
            this.repo = repo;
            this.videogamerepo = videogamerepo;
            this.franchiserepo = franchiserepo;
        }

        public void Create(Developer item)
        {
            if (item.DeveloperName.Length < 3)
            {
                throw new ArgumentException("Title is too short.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Developer Read(int id)
        {
            var developer = this.repo.Read(id);
            if (developer == null)
            {
                throw new ArgumentException("Developer doesn't exist.");
            }
            return developer;
        }

        public IQueryable<Developer> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Developer item)
        {
            this.repo.Update(item);
        }
    }
}
