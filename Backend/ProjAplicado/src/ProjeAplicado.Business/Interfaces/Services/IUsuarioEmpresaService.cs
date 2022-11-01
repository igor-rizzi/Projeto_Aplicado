using ProjAplicado.Business.Models;

namespace ProjAplicado.Business.Interfaces.Services
{
    public interface IUsuarioEmpresaService
    {
        Task<bool> Adicionar(UsuarioEmpresa usuarioEmpresa);
    }
}
