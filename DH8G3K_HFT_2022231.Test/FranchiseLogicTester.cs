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
    class FranchiseLogicTester
    {
        FranchiseLogic franchiselogic;
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
                new Videogame { VideogameId = 1, FranchiseId = 1, Title = "Dark Souls: Prepare To Die Edition", Rating = 9, Franchise = tesztadatok_franchise[0] },
                new Videogame { VideogameId = 2, FranchiseId = 1, Title = "Dark Souls: REMASTERED", Rating = 9.5, Franchise = tesztadatok_franchise[0] },
                new Videogame { VideogameId = 3, FranchiseId = 1, Title = "Dark Souls II", Rating = 9, Franchise = tesztadatok_franchise[0] },
                new Videogame { VideogameId = 4, FranchiseId = 1, Title = "Dark Souls II: Scholar of the First Sin", Rating = 9, Franchise = tesztadatok_franchise[0] },
                new Videogame { VideogameId = 5, FranchiseId = 1, Title = "Dark Souls III", Rating = 9, Franchise = tesztadatok_franchise[0] },

                new Videogame { VideogameId = 6, FranchiseId = 2, Title = "Elden Ring", Rating = 9.7, Franchise = tesztadatok_franchise[1] },

                new Videogame { VideogameId = 7, FranchiseId = 3, Title = "Overwatch", Rating = 10, Franchise = tesztadatok_franchise[2] },
            };
            mockVideogamerepo.Setup(a => a.ReadAll()).Returns(tesztadatok_videogame.AsQueryable());
            franchiselogic = new FranchiseLogic(mockFranchiserepo.Object, mockVideogamerepo.Object, mockDeveloperrepo.Object);
        }

        [Test]
        public void TotalNumberOfGamesByDeveloperTest()
        {
            IEnumerable<FranchiseInfo> actual = franchiselogic.FranchisesWithOnlyOneVideogame();
            List<FranchiseInfo> expected = new List<FranchiseInfo>()
            {
                new FranchiseInfo()
                {
                    FranchiseName = "Elden Ring Franchise",
                    NumberOfGames = 1
                },
            };
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void CreateTest()
        {
            var franchise = new Franchise() { FranchiseName = "Franchise1" };

            franchiselogic.Create(franchise);

            mockFranchiserepo.Verify(t => t.Create(franchise), Times.Once);
        }

        [Test]
        public void DeleteTest()
        {
            int id = 1;
            franchiselogic.Delete(id);
            mockFranchiserepo.Verify(t => t.Delete(id), Times.Once);
        }

        [Test]
        public void UpdateTest()
        {
            Franchise franchise = new Franchise { FranchiseId = 1, FranchiseName = "Dark Souls Franchise", NumberOfGames = 5, DeveloperId = 1 };
            franchiselogic.Update(franchise);
            mockFranchiserepo.Verify(t => t.Update(franchise), Times.Once);
        }
    }
}
