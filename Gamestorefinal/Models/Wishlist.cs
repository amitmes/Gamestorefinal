using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesStore.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<Games> Gameslist { get; set; }
    }
}
