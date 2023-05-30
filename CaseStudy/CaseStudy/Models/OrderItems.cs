using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMSProject.Models
{
    public class OrderItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Products Product { get; set; }
        [Required]
        public Orders Order { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int TotalPrice { get; set; }
    }
}

