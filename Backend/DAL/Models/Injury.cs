using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Injury
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        public DateTime Injury_Date { get; set; }

        [Required]
        [ForeignKey("Player")]
        public int Player_Id { get; set; }
        public virtual Player Player { get; set; }





        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
