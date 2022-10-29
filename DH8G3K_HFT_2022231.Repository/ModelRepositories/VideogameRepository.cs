using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Repository
{
    public class VideogameRepository : Repository<Videogame>, IRepository<Videogame>
    {
        public VideogameRepository(VideogameDbContext ctx) : base(ctx)
        {
        }

        public override Videogame Read(int id)
        {
            return ctx.Videogames.FirstOrDefault(t => t.VideogameId == id);
        }

        public override void Update(Videogame item)
        {
            var old = Read(item.VideogameId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
