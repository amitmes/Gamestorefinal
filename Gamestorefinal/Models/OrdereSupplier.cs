using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesStore.Models
{
    public class OrdereSupplier
    {
       
        public int Id { get; set; }
        [Required]
        [Display (Name ="Supplier")]
        public int SupplierId { get; set; }
        [Required]
        public Supplier Supplier { get; set; }
        public List<Order> GamesforOrder { get; set; }
        public float Totalprice { get; set; }


    }
}
