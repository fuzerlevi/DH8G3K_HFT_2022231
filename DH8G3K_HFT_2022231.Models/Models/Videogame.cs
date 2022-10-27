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

        [Range(0, 10000)]
        public int Income { get; set; }

        [Range(0, 10)]
        public int Rating { get; set; }
    }
}
