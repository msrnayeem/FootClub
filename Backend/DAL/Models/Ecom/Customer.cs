using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Ecom
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@gmail\.com$", ErrorMessage = "Invalid email format. Email should end with @gmail.com")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
