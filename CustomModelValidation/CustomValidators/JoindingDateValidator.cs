using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace CustomModelValidation.CustomValidators
{
    public class JoindingDateValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var container = validationContext.ObjectInstance;
            var DOBProperty = validationContext.ObjectInstance.GetType().GetProperty("DOB");
            if (DOBProperty == null)
            {
                return ValidationResult.Success;
            }
            DateTime DOB = (DateTime)DOBProperty.GetValue(container);
            DateTime JoiningDate = (DateTime)value;
            if (DOB >= JoiningDate) return new ValidationResult("Date of birth must be older than joining date");
            return ValidationResult.Success;
        }

    }
}
