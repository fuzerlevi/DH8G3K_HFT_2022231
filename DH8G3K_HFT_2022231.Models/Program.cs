using DH8G3K_HFT_2022231.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            VideogamesDbContext ctx = new VideogamesDbContext();

            ctx.Videogames.ToList().ForEach(t => Console.WriteLine(t.Title));
        }
    }
}
