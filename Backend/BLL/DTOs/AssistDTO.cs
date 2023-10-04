using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AssistDTO
    {
        public int Id { get; set; }

        public int NoOfAssist { get; set; }

        public int PlayerId { get; set; }

        public int UserId { get; set; }

    }
}
