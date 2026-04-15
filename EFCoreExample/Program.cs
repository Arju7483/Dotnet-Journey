using EFCoreExample.Infrastructure;
using EFCoreExample.Interfaces;
using EFCoreExample.Repositories;
using EFCoreExample.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Dependency Injection
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddSwaggerGen();
// logging provider configuration
// removing all default provider(console,debug,event log) and add console as log provider
builder.Logging.ClearProviders().AddConsole();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // This generates the green/blue webpage
}
app.UseStaticFiles();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
