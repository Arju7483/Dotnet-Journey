
namespace CustomMiddlewareSection4.NewFolder2
{
    public class CustomMiddlewareOne : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom middleware 1 starts\n");
            await next(context);
            await context.Response.WriteAsync("Custom middleware 1 end\n");
        }
    }
}
