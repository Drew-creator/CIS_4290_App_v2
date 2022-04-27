using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIS4290_App.Models
{
    public class User : IdentityUser
    {



        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }

  
        public string ExpDate { get; set; }

        public string Csv { get; set; }

      


        public float? Amount { get; set; }






    }
}
