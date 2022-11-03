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

        public async Task<bool> Adicionar(UsuarioEmpresa usuarioEmpresa)
        {
            await _usuarioEmpresaRepository.Adicionar(usuarioEmpresa);
            return true;
        }
    }
}
