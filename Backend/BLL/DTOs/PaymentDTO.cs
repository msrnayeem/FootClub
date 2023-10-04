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
    public class PaymentDTO
    {
        
        public int Id { get; set; }       
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }       
        public int PlayerId { get; set; }
        public int UserId { get; set; }
    }
}
