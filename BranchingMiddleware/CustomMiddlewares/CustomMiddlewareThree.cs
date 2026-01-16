
using System.Runtime.CompilerServices;

namespace BranchingMiddleware.CustomMiddlewares
{
    public class CustomMiddlewareThree : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is customMiddleware three\n");
            await next(context);
        }
    };
    public static class MiddlewareTreeExtension
    {
        public static IApplicationBuilder UseCustomMiddlewareThree(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddlewareThree>();
        }
    }
}
