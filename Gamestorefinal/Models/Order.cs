using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesStore.Models
{
    public class Order
        
    {
        public int Id { get; set; }
        public Games Game { get; set; }
        public int Quantity { get; set; }
    }
}
