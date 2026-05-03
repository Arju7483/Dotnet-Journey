using Microsoft.AspNetCore.Mvc.Filters;
using FilterExample.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace FilterExample.Filters.ActionFilters
{
    public class PersonActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("personDto"))
            {
                // validation check
                if (!context.ModelState.IsValid)
                {
                    // if result is set, it automatic short-circuit the request
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                // can be add or update reaquest header
                if(!context.HttpContext.Request.Headers.TryGetValue("X-CorrelationId",out var correlationID))
                {
                    context.HttpContext.Request.Headers.Add("X-CorrelationId", Guid.NewGuid().ToString());
                }
                // we can change requst argument or headers or any other properties
                var reqest = context.ActionArguments["personDto"];
                AddPersonDto req = (AddPersonDto)reqest;
                if (req?.Age < 18)
                {
                    context.ActionArguments["personDto"] = new AddPersonDto()
                    {
                        FirstName = req.FirstName,
                        LastName = req.LastName,
                        Age = 18,
                        Email = req.Email

                    };
                }

            }
        }
    }
}
