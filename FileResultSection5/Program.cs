var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
app.Map("/", async (context) =>
{
    await context.Response.WriteAsync("Hello world");
});
app.Run();
