using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Interfaces.Services;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Business.Services
{
    public class UsuarioEmpresaService : IUsuarioEmpresaService
    {
        private readonly IUsuarioEmpresaRepository _usuarioEmpresaRepository;

        public UsuarioEmpresaService(IUsuarioEmpresaRepository usuarioEmpresaRepository)
        {
            _usuarioEmpresaRepository = usuarioEmpresaRepository;
        }

        public Task<bool> Adicionar(UsuarioEmpresa usuarioEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
