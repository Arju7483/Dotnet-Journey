
namespace BranchingMiddleware.CustomMiddlewares
{
    public class BranchingMiddleWareOne : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is path based branching middleware one\n");
            await next(context);
        }
    }
    public static class BranchingMiddleWareOneExtension
    {
        public static IApplicationBuilder UseBranchingMiddlewareOne(this IApplicationBuilder app)
        {
            return app.UseMiddleware<BranchingMiddleWareOne>();
        }
    }
}
