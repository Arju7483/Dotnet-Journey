using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomModelBinder.CustomModelBinders
{
    public class EmployeeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));

            // 1. Extract values safely using FirstValue
            string name = bindingContext.ValueProvider.GetValue("Name").FirstValue;
            string email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            string dobRaw = bindingContext.ValueProvider.GetValue("DateOfBirth").FirstValue;
            string joinRaw = bindingContext.ValueProvider.GetValue("JoiningDate").FirstValue;

            // 2. Initialize the model
            Employee employee = new Employee
            {
                Name = name,
                Email = email
            };

            // 3. Safe Date Parsing
            if (DateTime.TryParse(dobRaw, out DateTime dob))
                employee.DateOfBirth = dob;

            if (DateTime.TryParse(joinRaw, out DateTime joinDate))
                employee.JoiningDate = joinDate;

            // 4. Complete the binding
            bindingContext.Result = ModelBindingResult.Success(employee);
            return Task.CompletedTask;
        }
    }
}
