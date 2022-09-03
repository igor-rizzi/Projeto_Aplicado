using ProjetoAplicado.Domain.Dtos;
using ProjetoAplicado.Interfaces.Services;
using System.Diagnostics.CodeAnalysis;
using System.ServiceProcess;

namespace ProjetoAplicado.Services
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        [ExcludeFromCodeCoverage]
        public async Task AdicionarAsync(UsuarioDto dto)
        {
            //await adicionarAsyncService.Exec(dto);
        }
    }
}
