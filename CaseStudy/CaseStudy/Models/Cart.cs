using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSProject.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Users User { get; set; }
        [Required]
        public Products Product { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int TotalPrice { get; set; }
    }
}

