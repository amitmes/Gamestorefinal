using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamesStore.Models
{
    public class Games
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public List<Category> Category { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "System requiremnts")]
        public string Systemrequiremnts { get; set; }
        [Required]
        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public DateTime Releasedate { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public float Price { get; set; }
        [DataType(DataType.Url)]
        [Required]
        public string Trailer { get; set; }
        
        public byte[] Image { get; set; }
        [NotMapped]
        public IFormFile Imagefile { get; set; }
        [Required]
        [Display(Name = "On stock")]
        public int Onstock { get; set; }
     
        public List<Supplier> Suppliers { get; set; }
    }
}
