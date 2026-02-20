using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
namespace IValidatableObjectExample.Models
{
    public class Employee : IValidatableObject
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        public string Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Convert.ToDateTime(DateOfBirth) > Convert.ToDateTime(JoiningDate))
            {
                yield return new ValidationResult("Joining Date must be newer than date of birth", new[] { nameof(JoiningDate) });
            }
            if (Country != null && Country != "Bangladesh")
            {
                yield return new ValidationResult("Country should be Bangladesh",new[] { nameof(Country) });
            }

        }
    }
}
