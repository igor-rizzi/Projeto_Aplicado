using ProjAplicado.Business.Interfaces;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _usuarioRepository.Adicionar(usuario);
        }
    }
}
