using System.ComponentModel.DataAnnotations;

namespace SectionSeven_assignment.CustomValidators
{
    public class DateValidator : ValidationAttribute
    {
        private readonly DateTime minimumDate;

        public DateValidator(string minimumDate)
        {
            this.minimumDate = DateTime.Parse(minimumDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Order Date is required");

            if (value is not DateTime date)
                return new ValidationResult("Invalid Order date format");

            if (date < minimumDate)
                return new ValidationResult($"Order Date must be greater than {minimumDate:yyyy-MM-dd}");

            return ValidationResult.Success;
        }
    }
}
