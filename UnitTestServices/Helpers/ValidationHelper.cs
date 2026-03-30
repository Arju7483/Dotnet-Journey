using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServices.Helpers
{
    public class ValidationHelper
    {
        internal static void ModelValidator(object model)
        {
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> result = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, context, result, true);
            if (!isValid)
            {
                throw new ArgumentException();
            }
        }
    }
}
