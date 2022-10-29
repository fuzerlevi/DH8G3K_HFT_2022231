using DH8G3K_HFT_2022231.Models;
using System.Linq;

namespace DH8G3K_HFT_2022231.Logic
{
    public interface IVideogameLogic
    {
        void Create(Videogame item);
        void Delete(int id);
        Videogame Read(int id);
        IQueryable<Videogame> ReadAll();
        void Update(Videogame item);
    }
}