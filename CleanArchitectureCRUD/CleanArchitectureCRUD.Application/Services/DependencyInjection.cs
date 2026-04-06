using CleanArchitectureCRUD.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace CleanArchitectureCRUD.Application.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            
            return services;
        }
    }
}
