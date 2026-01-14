using CustomMiddlewareSection4.NewFolder2;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddlewareOne>();
builder.Services.AddTransient<CustomMiddlewareTwo>();
builder.Services.AddTransient<CustomMiddlewareUsingExtensionMethod>();
var app = builder.Build();

app.Use( async (context, next) =>
{
    await context.Response.WriteAsync("middleware1 is starting \n");
    await next(context);
    await context.Response.WriteAsync("middleware1 is ending \n");
});
app.UseMiddleware<CustomMiddlewareOne>();
app.UseMiddleware<CustomMiddlewareTwo>();
app.UseCustomMiddlewareExtension();
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("middleware2 is starting \n");
    await next(context);
    await context.Response.WriteAsync("middleware2 is ending \n");
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("this is terminating middleware \n");
});
app.Run();
