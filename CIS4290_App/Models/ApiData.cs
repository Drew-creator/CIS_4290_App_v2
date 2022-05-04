using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CIS4290_App.Models
{
    [DataContract(Name = "PatchObject")]
    public class ApiData
    {
        [DataMember(Name = "value")]
        public float value { get; set; }
        [DataMember(Name = "path")]
        public string path { get; set; }
        [DataMember(Name = "op")]
        public string op { get; set; }
        [Key]
        [DataMember(Name = "CardNumber")]
        public string CardNumber { get; set; }
        [DataMember(Name = "ExpDate")]
        public string ExpDate { get; set; }
        [DataMember(Name = "Csv")]
        public string Csv { get; set; }
        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "LastName")]
        public string LastName { get; set; }
        [DataMember(Name = "UserName")]
        public string UserName { get; set; }
    }
}
