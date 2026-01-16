using BranchingMiddleware.CustomMiddlewares;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddlewareOne>();
builder.Services.AddTransient<BranchingMiddleWareOne>();
builder.Services.AddTransient<CustomMiddlewareTwo>();
builder.Services.AddTransient<CustomMiddlewareThree>();
builder.Services.AddTransient<BranchingMiddleWareTwo>();
var app = builder.Build();

app.UseCustomMiddlewareOne();
// path base branching middleware
app.Map("/path-base", app =>
{
    app.UseBranchingMiddlewareOne();
    app.UseCustomMiddlewareTwo();
});
// conditional branching
app.MapWhen(context => 
{ 
    if (context.Request.Query.ContainsKey("conditional")) return true; return false; 
},
app =>
{
    app.UseBranchingMiddlewareTwo();
});
// useWnen -> conditional middleware with rejoint
app.UseWhen(context => context.Request.Query.ContainsKey("rejoin"), app =>
{
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("This is rejoin branching middleware\n");
        await next(context);
    });
});
app.UseCustomMiddlewareThree();
app.Run();
