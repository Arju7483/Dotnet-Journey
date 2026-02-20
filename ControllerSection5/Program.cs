using ControllerSection5.Controllers;
using ControllerSection5.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TeacherDataService>();
builder.Services.AddControllers();
builder.Services.AddRouting();
var app = builder.Build();
app.MapControllers();
app.Run();
