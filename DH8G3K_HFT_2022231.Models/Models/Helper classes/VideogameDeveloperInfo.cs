using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Models.Models.Helper_classes
{
    public class VideogameDeveloperInfo
    {
        public string Title { get; set; }

        public string Developername { get; set; }

        public override bool Equals(object obj)
        {
            return (Developername == (obj as VideogameDeveloperInfo).Developername && Title == (obj as VideogameDeveloperInfo).Title);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
