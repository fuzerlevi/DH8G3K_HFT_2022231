using DH8G3K_HFT_2022231.Logic;
using DH8G3K_HFT_2022231.Models.Models.Helper_classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DH8G3K_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IDeveloperLogic developertlogic;
        IFranchiseLogic franchiselogic;
        IVideogameLogic videogamelogic;

        public StatController(IDeveloperLogic developertlogic, IFranchiseLogic franchiselogic, IVideogameLogic videogamelogic)
        {
            this.developertlogic = developertlogic;
            this.franchiselogic = franchiselogic;
            this.videogamelogic = videogamelogic;
        }

        //developer's non-cruds

        [HttpGet("{id}")]
        public int TotalNumberOfGamesByDeveloper(int id)
        {
            int TotalNumberOfGamesByDeveloper = this.developertlogic.TotalNumberOfGamesByDeveloper(id);
            return TotalNumberOfGamesByDeveloper;
        }

        //franchise's non-cruds

        [HttpGet]
        public IEnumerable<FranchiseInfo> NumberOfGamesInFranchise()
        {
            var numberofgames = this.franchiselogic.FranchisesWithOnlyOneVideogame();
            return numberofgames;
        }



        // videogame's non-cruds

        [HttpGet]
        public IEnumerable<VideogameDeveloperInfo> VideogamesWithDevelopernames()
        {
            var info = this.videogamelogic.VideogamesWithDeveloperNames();
            return info;
        }

        [HttpGet]
        public IEnumerable<VideogameYearInfo> WhenWereVideogamesMade()
        {
            var info = this.videogamelogic.WhenWereVideogamesMade();
            return info;
        }

        [HttpGet("{year}")]
        public IEnumerable<VideogamesOfYearInfo> VideogamesOfYearX(int year)
        {
            var videogamesofyearx = this.videogamelogic.VideogamesOfYearX(year);
            return videogamesofyearx;
        }

        [HttpGet]
        public BestRatedVideogameInfo BestRatedVideogame()
        {
            var bestrated = this.videogamelogic.BestRatedVideogame();
            return bestrated;
        }
    }
}
