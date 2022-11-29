using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Logic
{
    public class FranchiseLogic : IFranchiseLogic
    {
        IRepository<Franchise> repo;
        IRepository<Videogame> videogamerepo;
        IRepository<Developer> developerrepo;

        public FranchiseLogic(IRepository<Franchise> repo, IRepository<Videogame> videogamerepo, IRepository<Developer> developerrepo)
        {
            this.repo = repo;
            this.videogamerepo = videogamerepo;
            this.developerrepo = developerrepo;
        }

        public void Create(Franchise item)
        {
            if (item.FranchiseName.Length < 3)
            {
                throw new ArgumentException("Title is too short.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Franchise Read(int id)
        {
            var franchise = this.repo.Read(id);
            if (franchise == null)
            {
                throw new ArgumentException("Franchise doesn't exist.");
            }
            return franchise;
        }

        public IQueryable<Franchise> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Franchise item)
        {
            this.repo.Update(item);
        }
    }
}
