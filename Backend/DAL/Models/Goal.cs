﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Goal
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int NoOfGoal { get; set; }

        [ForeignKey("Player")]
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }


    }
}
