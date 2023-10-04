using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
