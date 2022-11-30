using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Models.Models.Helper_classes
{
    public class FranchiseInfo
    {
        public string FranchiseName { get; set; }

        public int NumberOfGames { get; set; }

        public override bool Equals(object obj)
        {
            return (FranchiseName == (obj as FranchiseInfo).FranchiseName && NumberOfGames == (obj as FranchiseInfo).NumberOfGames);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
