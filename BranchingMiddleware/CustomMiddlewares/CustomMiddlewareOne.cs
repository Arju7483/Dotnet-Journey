
using System.Runtime.CompilerServices;

namespace BranchingMiddleware.CustomMiddlewares
{
    public class CustomMiddlewareOne : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is customMiddleware One\n");
            await next(context);
        }
    };
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddlewareOne(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddlewareOne>();
        }
    }
}
