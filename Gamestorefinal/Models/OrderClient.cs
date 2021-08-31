using GamesStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesStore.Models
{
    public class OrderClient
    {
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public List<Order> Games { get; set; }

        [DataType(DataType.CreditCard)]
        [Required]
        [Display(Name = "Credit card")]
        public string Creditcard { get; set; }
        [DataType(DataType.Currency)]
        public float Totalprice { get; set; }
        [Display(Name = "Order Date")]

        public DateTime DateTime { get; set; }
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The city must contain only letters")]
        [Required]

        public string City { get; set; }
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The street must contain only letters")]
        [Required]

        public string Street { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "The building number must contain only letters")]
        [Required]
        [Display(Name = "Building number")]

        public string Buildingnumber { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "The apartment number must contain only letters")]
        [Display(Name = "Apartment number")]

        public string Apartmentnumber { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "The zip code must contain only letters")]
        [Required]
        [Display(Name = "Zip code")]

        public string Zipcode { get; set; }
        [DataType(DataType.Text)]
        public String Comment { get; set; }

        public bool Status { get; set; }

    }
}
