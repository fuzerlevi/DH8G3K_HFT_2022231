using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Models.Models.Helper_classes
{
    public class VideogameYearInfo
    {
        public string Title { get; set; }

        public int Release { get; set; }

        public override bool Equals(object obj)
        {
            return (Title == (obj as VideogameYearInfo).Title);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
