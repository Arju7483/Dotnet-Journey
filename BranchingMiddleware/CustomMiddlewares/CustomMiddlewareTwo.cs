
using System.Runtime.CompilerServices;

namespace BranchingMiddleware.CustomMiddlewares
{
    public class CustomMiddlewareTwo : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is customMiddleware Two\n");
            await next(context);
        }
    };
    public static class MiddlewareTwoExtension
    {
        public static IApplicationBuilder UseCustomMiddlewareTwo(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddlewareTwo>();
        }
    }
}
