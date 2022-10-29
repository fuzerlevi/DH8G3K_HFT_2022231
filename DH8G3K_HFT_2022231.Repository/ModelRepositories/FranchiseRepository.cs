using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Repository
{
    public class FranchiseRepository : Repository<Franchise>, IRepository<Franchise>
    {
        public FranchiseRepository(VideogameDbContext ctx) : base(ctx)
        {
        }

        public override Franchise Read(int id)
        {
            return ctx.Franchises.FirstOrDefault(t => t.FranchiseId == id);
        }

        public override void Update(Franchise item)
        {
            var old = Read(item.FranchiseId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
