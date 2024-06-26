﻿using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Repository
{
    public class DeveloperRepository : Repository<Developer>, IRepository<Developer>
    {
        public DeveloperRepository(VideogameDbContext ctx) : base(ctx)
        {
        }

        public override Developer Read(int id)
        {
            return ctx.Developers.FirstOrDefault(t => t.DeveloperId == id);
        }

        public override void Update(Developer item)
        {
            var old = Read(item.DeveloperId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
