using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CustomModelValidation.CustomValidators;
namespace CustomModelValidation.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = new Guid();
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Range(18,40,ErrorMessage ="{0} should be in range {1} to {2}")]
        public int Age { get; set; }
        [DisplayName("Date Of Birth")]
        [DateOfBirthValidator(1990,ErrorMessage ="Birth year should be greater than 1990")]
        public DateTime DOB { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Dept { get; set; }

        // custom validation with validationContext
        // we complare joining date with Date of birth
        [Required(ErrorMessage ="Joining Date is required")]
        [JoindingDateValidator]
        public DateTime JoiningDate { get; set; }

    }
}
