using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesStore.Models
{

    public enum UserType
    {
        Visitor,
        Client,
        Admin
    }


    public class Client
    {
        public int Id { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The first name must contain only letters")]
        [Required]
        public string FirstName { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The last name must contain only letters")]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        public List<OrderClient> OrderClient { get; set; }
        public Wishlist WishList { get; set; }

        public UserType Type { get; set; } = UserType.Visitor;

    }
}
