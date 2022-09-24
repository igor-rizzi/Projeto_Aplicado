using ProjAplicado.Business.Interfaces;
using ProjAplicado.Business.Services;
using ProjAplicado.Data.Context;
using ProjAplicado.Data.Repository;

namespace ProjAplicado.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApiDbContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
