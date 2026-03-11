using OptionsPatternExample.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Options Pattern registration
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
var app = builder.Build();
app.MapControllers();
app.Run();
