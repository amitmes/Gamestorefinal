using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesStore.Models
{
    public class Games
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Category> Category { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "System requiremnts")]
        public string Systemrequiremnts { get; set; }
        [Required]
        [Display(Name = "Release date")]
        public DateTime Releasedate { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public float Price { get; set; }
        [DataType(DataType.Url)]
        [Required]
        public string Trailer { get; set; }
        [DataType(DataType.ImageUrl)]
        [Required]
        public string Image { get; set; }
        [Required]
        [Display(Name = "On stock")]
        public int Onstock { get; set; }
        [Required]
        public List<Supplier> Suppliers { get; set; }
    }
}
