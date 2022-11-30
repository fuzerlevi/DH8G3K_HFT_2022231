using DH8G3K_HFT_2022231.Models;
using DH8G3K_HFT_2022231.Models.Models.Helper_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Logic
{
    public interface IFranchiseLogic
    {
        void Create(Franchise item);
        void Delete(int id);
        Franchise Read(int id);
        IQueryable<Franchise> ReadAll();
        void Update(Franchise item);

        IEnumerable<FranchiseInfo> NumberOfGamesInFranchise();
    }
}
