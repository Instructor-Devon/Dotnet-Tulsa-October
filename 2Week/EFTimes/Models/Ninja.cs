using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBTimes.Models
{
    // Entity
    [Table("ninjas")]
    public class Ninja
    {
        [Key]
        [Column("ninja_id")]
        public int NinjaId {get;set;}
        [Required]
        [MinLength(2, ErrorMessage="Name must be 2 or more characters.")]
        [Display(Name="Turtle Name")]
        [Column("name", TypeName="VARCHAR(45)")]
        public string Name {get;set;}
        [Required(ErrorMessage="Color is required dudes!")]
        [EmailAddress]
        public string Email {get;set;}
        [DataType(DataType.Password)]
        public string SecretCode {get;set;}
        public string Color {get;set;}
        [MinLength(10)]
        public string Bio {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
      
    }
}