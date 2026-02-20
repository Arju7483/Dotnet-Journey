using System.ComponentModel.DataAnnotations;

namespace CustomModelValidation.CustomValidators
{
    public class DateOfBirthValidator: ValidationAttribute
    {
        public int minimumYear { get; set; } = 2000;
        // parameterless constructor
        public DateOfBirthValidator()
        {

        }
        // parameterized constructor
        public DateOfBirthValidator(int minimumYear)
        {
            this.minimumYear = minimumYear;
        }
        

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null) return new ValidationResult("DOB is empty");
            if(value is not DateTime date)
            {
                return new ValidationResult("Invalied format");
            }
            if(date.Year < minimumYear)
            {
                return new ValidationResult(ErrorMessage ?? $"Year should be greater than {minimumYear}");
            }
            if (date > DateTime.Now) return new ValidationResult("Date of Birth can not be in future");

            if (DateTime.Now.Year - date.Year < 18) return new ValidationResult("Minimum year 18");
            return ValidationResult.Success;
            
            
        }
    }
 
}
