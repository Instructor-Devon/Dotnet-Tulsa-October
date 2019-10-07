using System.ComponentModel.DataAnnotations;

namespace SessionTimes.Models
{
    public class Ninja
    {
        [Required]
        [MinLength(2, ErrorMessage="Name must be 2 or more characters.")]
        [Display(Name="Turtle Name")]
        public string Name {get;set;}
        [Required(ErrorMessage="Color is required dudes!")]
        [EmailAddress]
        public string Email {get;set;}
        [DataType(DataType.Password)]
        public string SecretCode {get;set;}
        public string Color {get;set;}
        [MinLength(10)]
        public string Bio {get;set;}
    }
}