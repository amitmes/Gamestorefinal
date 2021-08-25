using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesStore.Models
{
    public class Locations
    {
        public int Id { get; set; }

        public string Adress_name { get; set; }

        public float Cor_x { get; set; }

        public float Cor_y { get; set; }
    }
}
