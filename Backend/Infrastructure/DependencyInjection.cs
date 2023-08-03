using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IInspectionRepository, InspectionRepository>();
            services.AddScoped<IInspectionTypeRepository, InspectionTypeRepository>();
            services.AddScoped<FluentValidations>();

            return services;
        }
    }
}