using InterfacesForUnitTestExample;
using UnitTestServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICountryService, CountryService>();
var app = builder.Build();


app.Run();
