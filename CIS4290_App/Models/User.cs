using Microsoft.AspNetCore.Identity;

namespace CIS4290_App.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
