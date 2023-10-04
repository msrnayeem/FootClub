using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RatingDTO
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Rating_point { get; set; }

        [Required]
        public DateTime Last_Updated_Date { get; set; }

        [Required]
        public string Player_Id { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
