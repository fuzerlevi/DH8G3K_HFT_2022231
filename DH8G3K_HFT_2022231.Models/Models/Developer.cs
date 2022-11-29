using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Models
{
    public class Developer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeveloperId { get; set; }

        [Required]
        [StringLength(240)]
        public string DeveloperName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Franchise> Franchises { get; set; }
        public Developer()
        {
            Franchises = new HashSet<Franchise>();
        }

        public Developer(string line)
        {
            string[] split = line.Split('#');
            DeveloperId = int.Parse(split[0]);
            DeveloperName = split[1];
            Franchises = new HashSet<Franchise>();
        }
    }
}
