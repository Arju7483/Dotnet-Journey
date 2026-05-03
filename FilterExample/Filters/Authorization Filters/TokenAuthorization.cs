using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterExample.Filters.Authorization_Filters
{
    public class TokenAuthorization : IAsyncAuthorizationFilter
    {
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Now that we have Cookie Authentication configured, we can check the User Identity
            if (context.HttpContext.User.Identity == null || !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
            }
            return Task.CompletedTask;
        }
    }
}
