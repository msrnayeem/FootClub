using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class InjuryDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Event { get; set; }

        [Required]
        public DateTime Injury_Date { get; set; }

        [Required]
        public string Player_Id { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
