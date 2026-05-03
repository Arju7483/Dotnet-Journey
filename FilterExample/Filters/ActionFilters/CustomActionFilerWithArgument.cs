using Microsoft.AspNetCore.Mvc.Filters;
namespace FilterExample.Filters.ActionFilters
{
    public class CustomActionFilerWithArgument : IActionFilter
    {
        private readonly ILogger<CustomActionFilerWithArgument> _logger;
        private readonly int argument1;
        public CustomActionFilerWithArgument(ILogger<CustomActionFilerWithArgument> logger, int arg1)
        {
            _logger = logger;
            argument1 = arg1;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogWarning("The value of argument passed is {argument1}", argument1);
        }
    }
}
