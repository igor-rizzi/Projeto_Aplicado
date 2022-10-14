using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Interfaces.Services;
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
            services.AddScoped<IVagaRepository, VagaRepository>();
            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVagaService, VagaService>();
            services.AddScoped<ICandidatoService, CandidatoService>();
            services.AddScoped<IEmpresaService, EmpresaService>();

            return services;
        }
    }
}
