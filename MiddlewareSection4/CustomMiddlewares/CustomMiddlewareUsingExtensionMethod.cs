
namespace CustomMiddlewareSection4.NewFolder2
{
    public class CustomMiddlewareUsingExtensionMethod : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is custom middleware, using it like built in middleware by extension method\n");
            await next(context);
        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddlewareExtension(this IApplicationBuilder app) {
           return app.UseMiddleware<CustomMiddlewareUsingExtensionMethod>();
        }
    }

}
