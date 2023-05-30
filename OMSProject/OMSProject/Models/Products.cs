using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMSProject.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Seller { get; set; }
        [Required]
        public int Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }

    }
}
