using ProjAplicado.Business.Models;

namespace ProjAplicado.Business.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> Adicionar(Usuario usuario);
    }
}
