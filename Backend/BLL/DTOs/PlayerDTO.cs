using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Height { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int Price { get; set; }
    }
}
