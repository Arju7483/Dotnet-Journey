using CleanArchitectureCRUD.Application.Interfaces;
using CleanArchitectureCRUD.Application.Services;
using CleanArchitectureCRUD.Infrastructure.Data;
using CleanArchitectureCRUD.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 1. This will now be recognized after installing the package!
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddApplicationServices();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// 2. YOU NEED TO ADD THESE LINES HERE TO SHOW THE UI!
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // This generates the green/blue webpage
}

app.MapControllers();
app.UseStaticFiles();

app.Run();