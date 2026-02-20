var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// static file middleware
app.UseStaticFiles();
// example of default routing parameter
app.MapGet("/get/{id=1}", async (context) =>
{
    var id = context.Request.RouteValues["id"];
    int.TryParse(id.ToString(), out int x);
    await context.Response.WriteAsync($"simple routing with default constant with id : {x}");
});

// example of route constant which accept only alphabet
app.MapGet("/get/{id:regex(^[a-zA-Z]+$)}", async (context) => {
    var param = context.Request.RouteValues["id"];
    await context.Response.WriteAsync($"example of routing constant with alphabet: {param}");
});
app.MapPost("/", async (context) =>
{
    await context.Response.WriteAsync("simple routing post.");
});
app.Run();
