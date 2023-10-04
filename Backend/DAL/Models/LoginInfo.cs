using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LoginInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@gmail\.com$", ErrorMessage = "Invalid email format. Email should end with @gmail.com")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string TableName { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
