using ProjAplicado.Business.Models;

namespace ProjAplicado.Business.Interfaces.Services
{
    public interface ICandidatoService
    {
        Task<bool> Adicionar(Candidato candidato);
    }
}
