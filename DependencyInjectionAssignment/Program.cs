using ICityWeatherServices;
using CityWeatherServices;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICityWeatherService, CityWeatherService>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

app.Run();
