using Interfaces;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICitiesService, CitiesService>();
//builder.Services.AddSingleton<ICitiesService,CitiesService>();
var app = builder.Build();
app.MapControllers();
app.Run();
