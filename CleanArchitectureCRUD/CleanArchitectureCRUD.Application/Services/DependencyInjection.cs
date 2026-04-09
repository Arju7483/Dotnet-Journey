using CleanArchitectureCRUD.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace CleanArchitectureCRUD.Application.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            
            return services;
        }
    }
}
