var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Map("/", () => "Hello World!");
app.Use(async ( context,  next) =>
{
    await context.Response.WriteAsync("Getting Response from First Middleware\n");
    await next();
});
app.Run(async(context) =>
{
    await context.Response.WriteAsync("response from 1st terminal middle ware");
    
});
app.Run(async (context) =>
{
    await context.Response.WriteAsync("response from 2nd terminal middle ware");
});
app.Run();
