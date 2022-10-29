using System;
using System.Linq;
using DH8G3K_HFT_2022231.Logic;
using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Repository;
using DH8G3K_HFT_2022231.Repository.Database;

namespace DH8G3K_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new VideogameDbContext();
            var repo = new VideogameRepository(ctx); 
            var logic = new VideogameLogic(repo);
            
        }
    }
}
