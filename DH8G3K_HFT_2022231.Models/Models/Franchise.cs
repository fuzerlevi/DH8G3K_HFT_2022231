using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Models
{
    public class Franchise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FranchiseId { get; set; }

        [Required]
        [StringLength(240)]
        public string FranchiseName { get; set; }

        [Range(1,10)]
        public int NumberOfGames { get; set; }

        public int DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }

        public virtual ICollection<Videogame> Videogames { get; set; }

        public Franchise()
        {

        }

        public Franchise(string line)
        {
            string[] split = line.Split('#');
            FranchiseId = int.Parse(split[0]);
            DeveloperId = int.Parse(split[1]);
            FranchiseName = split[2];
            NumberOfGames = int.Parse(split[3]);
        }
    }
}
