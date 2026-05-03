using AuthorizationExample;
using AuthorizationExample.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AuthorizationExample.Repository;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Required for MapControllers()
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
// 2. Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// 4. Identity Setup
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    // password configuration
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = true;

}).AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders();

var app = builder.Build();

// 5. Middleware Pipeline (ORDER MATTERS!)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty; // Swagger will open at the root URL
    });
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Who are you?
app.UseAuthorization();  // we can also configuration authorization middleware globally so that it will be applicable for each action method

app.MapControllers();    // This replaces "controllermap"

app.Run();