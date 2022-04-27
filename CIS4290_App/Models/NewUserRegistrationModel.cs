
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIS4290_App.Models
{
    public class NewUserRegistrationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string CardNumber { get; set; }
        public string ExpDate { get; set; }
        public string Csv { get; set; }

        [DataType(DataType.Currency)]

        [Range(0, 500, ErrorMessage = "Please Enter Amount Under $0-$500")]
        public float? Amount { get; set; }
    }
}
