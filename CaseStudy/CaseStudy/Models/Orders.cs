using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OMSProject.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Users User { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

    }
}

