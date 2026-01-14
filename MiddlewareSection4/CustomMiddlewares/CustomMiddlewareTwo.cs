
namespace CustomMiddlewareSection4.NewFolder2
{
    public class CustomMiddlewareTwo : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom middleware 2 starts\n");
            await next(context);
            await context.Response.WriteAsync("Custom middleware 2 end\n");
        }
    }
}
