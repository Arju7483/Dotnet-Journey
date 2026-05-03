using System.ComponentModel.DataAnnotations;

namespace AuthorizationExample.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public  string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public DateTime DOB {  get; set; }

    }
}
