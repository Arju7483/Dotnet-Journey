
namespace BranchingMiddleware.CustomMiddlewares
{
    public class BranchingMiddleWareTwo : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is conditional branching middleware two\n");
            await next(context);
        }
    }
    public static class BranchingMiddleWareTwoExtension
    {
        public static IApplicationBuilder UseBranchingMiddlewareTwo(this IApplicationBuilder app)
        {
            return app.UseMiddleware<BranchingMiddleWareTwo>();
        }
    }
}
