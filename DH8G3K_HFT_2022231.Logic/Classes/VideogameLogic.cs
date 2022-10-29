using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Repository;

namespace DH8G3K_HFT_2022231.Logic
{
    public class VideogameLogic : IVideogameLogic
    {
        IRepository<Videogame> repo;

        public VideogameLogic(IRepository<Videogame> repo)
        {
            this.repo = repo;
        }

        public void Create(Videogame item)
        {
            if (item.Title.Length < 3)
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
    }
}
