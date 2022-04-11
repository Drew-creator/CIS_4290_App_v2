using System.ComponentModel.DataAnnotations;

namespace CIS4290_App.Models
{
    public class UserRegistrationModel
    {
        public string CardNumber { get; set; }

        public string ExpDate { get; set; }

        public string Csv { get; set; }
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

        // [CreditCard]
    }
}
