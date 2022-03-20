using System;
using System.ComponentModel.DataAnnotations;

namespace CIS4290_App.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
