using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Rating_point { get; set; }

        [Required]
        public DateTime Last_Updated_Date { get; set; }


        [ForeignKey("Player")]
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
