using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The category name must contain only letters")]
        [Required]
        public string Name { get; set; }
        public List<Games> Games { get; set; }
        
    }
}
