using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Ecom
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Status { get; set; }  

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
