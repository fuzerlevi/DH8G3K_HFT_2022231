using System;

namespace TESZTER_PROJEKT
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
