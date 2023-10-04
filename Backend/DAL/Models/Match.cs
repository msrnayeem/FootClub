using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public string Opponent { get; set; }

        [Required]
        public string Tournament { get; set; }
        [Required]
        public string Region { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
