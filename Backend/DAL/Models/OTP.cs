using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OTP
    {
        [Key]
        public int Id { get; set; }

        public int Otp {get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
