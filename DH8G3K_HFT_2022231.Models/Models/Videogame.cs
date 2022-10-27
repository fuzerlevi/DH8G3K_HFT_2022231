using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Models
{
    class Videogame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VideogameId { get; set; }

        [Required]
        [StringLength(240)]
        public string Title { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public DateTime Release { get; set; }

        public int FranchiseId { get; set; }

        public Videogame()
        {
            
        }

        public Videogame(string line)
        {
            string[] split = line.Split('#');
            VideogameId = int.Parse(split[0]);
            FranchiseId = int.Parse(split[1]);
            Title = split[2];
            Release = DateTime.Parse(split[4].Replace('*', '.'));
            Rating = double.Parse(split[5]);
        }
    }
}
