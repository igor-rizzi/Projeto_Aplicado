using ProjetoAplicado.Domain.Dtos;

namespace ProjetoAplicado.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task AdicionarAsync(UsuarioDto dto);
    }
}
