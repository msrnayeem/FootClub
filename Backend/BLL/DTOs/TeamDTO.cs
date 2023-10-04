using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }

        public string PlayerName { get; set; }

        public string PlayerPosition { get; set; }

        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int UserId { get; set; }

    }
}
