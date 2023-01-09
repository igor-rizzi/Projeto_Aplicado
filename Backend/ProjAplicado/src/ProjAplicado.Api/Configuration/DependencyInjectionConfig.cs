using ProjAplicado.Business.Intefaces.Notification;
using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Interfaces.Services;
using ProjAplicado.Business.Notificacoes;
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
            services.AddScoped<IUsuarioEmpresaRepository, UsuarioEmpresaRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVagaService, VagaService>();
            services.AddScoped<ICandidatoService, CandidatoService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IUsuarioEmpresaService, UsuarioEmpresaService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
