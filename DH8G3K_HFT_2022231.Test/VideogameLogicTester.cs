using DH8G3K_HFT_2022231.Logic;
using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Models.Models.Helper_classes;
using DH8G3K_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Test
{
    class VideogameLogicTester
    {
        VideogameLogic videogamelogic;
        Mock<IRepository<Franchise>> mockFranchiserepo;
        Mock<IRepository<Developer>> mockDeveloperrepo;
        Mock<IRepository<Videogame>> mockVideogamerepo;

        [SetUp]
        public void Init()
        {
            mockFranchiserepo = new Mock<IRepository<Franchise>>();
            mockDeveloperrepo = new Mock<IRepository<Developer>>();
            List<Developer> tesztadatok_developer = new List<Developer>()
            {
                new Developer { DeveloperId = 1, DeveloperName = "FromSoftware" },
                new Developer { DeveloperId = 2, DeveloperName = "Blizzard Entertainment" },
                new Developer { DeveloperId = 3, DeveloperName = "SEGA" },
            };
            mockDeveloperrepo.Setup(a => a.ReadAll()).Returns(tesztadatok_developer.AsQueryable());
            List<Franchise> tesztadatok_franchise = new List<Franchise>()
            {
                new Franchise { FranchiseId = 1, FranchiseName = "Dark Souls Franchise", NumberOfGames = 5, DeveloperId = 1, Developer = tesztadatok_developer[0] },
                new Franchise { FranchiseId = 2, FranchiseName = "Elden Ring Franchise", NumberOfGames = 1, DeveloperId = 1, Developer = tesztadatok_developer[0] },
                new Franchise { FranchiseId = 3, FranchiseName = "Overwatch Franchise", NumberOfGames = 2, DeveloperId = 2, Developer = tesztadatok_developer[1] },
                new Franchise { FranchiseId = 4, FranchiseName = "Warcraft Franchise", NumberOfGames = 2, DeveloperId = 2, Developer = tesztadatok_developer[1] },
                new Franchise { FranchiseId = 5, FranchiseName = "Sonic the Hedgehog Franchise", NumberOfGames = 9, DeveloperId = 3, Developer = tesztadatok_developer[2] },
                new Franchise { FranchiseId = 6, FranchiseName = "Yakuza Franchise", NumberOfGames = 6, DeveloperId = 3, Developer = tesztadatok_developer[2] },
            };
            mockFranchiserepo.Setup(a => a.ReadAll()).Returns(tesztadatok_franchise.AsQueryable());
            mockVideogamerepo = new Mock<IRepository<Videogame>>();
            List<Videogame> tesztadatok_videogame = new List<Videogame>()
            {
                new Videogame { VideogameId = 1, FranchiseId = 1, Title = "Dark Souls: Prepare To Die Edition", Rating = 9, Franchise = tesztadatok_franchise[0], Release = new DateTime(2011, 9, 22) },
                new Videogame { VideogameId = 2, FranchiseId = 1, Title = "Dark Souls: REMASTERED", Rating = 9.5, Franchise = tesztadatok_franchise[0], Release = new DateTime(2018, 5, 24) },
                new Videogame { VideogameId = 3, FranchiseId = 1, Title = "Dark Souls II", Rating = 9, Franchise = tesztadatok_franchise[0], Release = new DateTime(2014, 03, 11) },
                new Videogame { VideogameId = 4, FranchiseId = 1, Title = "Dark Souls II: Scholar of the First Sin", Rating = 9, Franchise = tesztadatok_franchise[0], Release = new DateTime(2015, 4, 1) },
                new Videogame { VideogameId = 5, FranchiseId = 1, Title = "Dark Souls III", Rating = 9, Franchise = tesztadatok_franchise[0], Release = new DateTime(2016, 3, 24) },

                new Videogame { VideogameId = 6, FranchiseId = 2, Title = "Elden Ring", Rating = 9.7, Franchise = tesztadatok_franchise[1], Release = new DateTime(2022, 2, 25) },

                new Videogame { VideogameId = 7, FranchiseId = 3, Title = "Overwatch", Rating = 10, Franchise = tesztadatok_franchise[2], Release = new DateTime(2015, 10, 4) },
            };
            mockVideogamerepo.Setup(a => a.ReadAll()).Returns(tesztadatok_videogame.AsQueryable());
            videogamelogic = new VideogameLogic(mockVideogamerepo.Object, mockDeveloperrepo.Object, mockFranchiserepo.Object);
        }

        //[Test]
        //public void VideogamesOfYear2015()
        //{
        //    var videogames = videogamelogic.VideogamesOfYearX(2015).ToList();

        //    var expectedvideogames = new List<VideogameYearInfo>()
        //    {
        //        new VideogameYearInfo { Title = "Dark Souls II: Scholar of the First Sin",  Release = 2015},
        //        new VideogameYearInfo { Title = "Overwatch",  Release = 2015},

        //    };
        //    Assert.AreEqual(videogames, expectedvideogames);
        //}



        [Test]
        public void TenOutOfTenVideogamesTest()
        {
            BestRatedVideogameInfo bestrated = videogamelogic.TenOutOfTenVideogames();
            BestRatedVideogameInfo expected = new BestRatedVideogameInfo() { Title = "Overwatch", Rating = 10 };
            Assert.AreEqual(bestrated, expected);
        }

        [Test]
        public void WhenWereVideogamesMadeTest()
        {
            var info = videogamelogic.WhenWereVideogamesMade().ToList();
            var expectedinfo = new List<VideogameYearInfo>()
            {
                new VideogameYearInfo()
                {
                    Title = "Dark Souls: Prepare To Die Edition",
                    Release = 2011
                },
                new VideogameYearInfo()
                {
                    Title = "Dark Souls: REMASTERED",
                    Release = 2018
                },
                new VideogameYearInfo()
                {
                    Title = "Dark Souls II",
                    Release = 2014
                },
                new VideogameYearInfo()
                {
                    Title = "Dark Souls II: Scholar of the First Sin",
                    Release = 2015
                },
                new VideogameYearInfo()
                {
                    Title = "Dark Souls III",
                    Release = 2016
                },
                new VideogameYearInfo()
                {
                    Title = "Elden Ring",
                    Release = 2022
                },
                new VideogameYearInfo()
                {
                    Title = "Overwatch",
                    Release = 2015
                },
            };
            Assert.AreEqual(info, expectedinfo);
        }

        [Test]
        public void VideogamesWithDeveloperNamesTest()
        {
            var info = videogamelogic.VideogamesWithDeveloperNames().ToList();
            var expectedinfo = new List<VideogameDeveloperInfo>()
            {
                new VideogameDeveloperInfo()
                {
                    Title = "Dark Souls: Prepare To Die Edition",
                    Developername = "FromSoftware"
                },
                new VideogameDeveloperInfo()
                {
                    Title = "Dark Souls: REMASTERED",
                    Developername = "FromSoftware"
                },
                new VideogameDeveloperInfo()
                {
                    Title = "Dark Souls II",
                    Developername = "FromSoftware"
                },
                new VideogameDeveloperInfo()
                {
                    Title = "Dark Souls II: Scholar of the First Sin",
                    Developername = "FromSoftware"
                },
                new VideogameDeveloperInfo()
                {
                    Title = "Dark Souls III",
                    Developername = "FromSoftware"
                },
                new VideogameDeveloperInfo()
                {
                    Title = "Elden Ring",
                    Developername = "FromSoftware"
                },
                new VideogameDeveloperInfo()
                {
                    Title = "Overwatch",
                    Developername = "Blizzard Entertainment"
                },
            };
            Assert.AreEqual(info, expectedinfo);
        }
    }
}
