using API.ApplicationCore.Interfaces;
using API.ApplicationCore.Services;

namespace API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IVeiculoService,VeiculoService>();
            services.AddScoped<IAdministradorService, AdministradorService>();
            return services;
        }
    }
}
