using HttpClientExample2.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<FinnhumService>();
var app = builder.Build();

app.Run();
