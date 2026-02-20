using System.ComponentModel.DataAnnotations;

namespace ModelBindingWithValidation.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3,ErrorMessage = "{0} should be less than 10 character")]
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Range(18,100, ErrorMessage = "{0} must in range {1} to {2}")]
        public int Age { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Passord not match")]
        public string ConfirmPassword { get; set; }
        public string Phone {  get; set; }


    }
}
