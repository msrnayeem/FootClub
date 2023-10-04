using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class GoalDTO
    {
        
        public int Id { get; set; }

        public int NoOfGoal { get; set; }


        public int PlayerID { get; set; }


        public int UserId { get; set; }
    }
}
