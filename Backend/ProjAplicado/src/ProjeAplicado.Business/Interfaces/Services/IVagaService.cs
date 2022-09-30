using ProjAplicado.Business.Models;

namespace ProjAplicado.Business.Interfaces.Services
{
    public interface IVagaService
    {
        Task<bool> Adicionar(Vaga vaga);
    }
}
