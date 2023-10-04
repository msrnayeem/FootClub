using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MatchDTO
    {
        public int Id { get; set; }

        public DateTime MatchDate { get; set; }

        public string Opponent { get; set; }
        public string Tournament {get; set;}

        public string Region { get; set; }
        public int UserId { get; set; }

    }
}
