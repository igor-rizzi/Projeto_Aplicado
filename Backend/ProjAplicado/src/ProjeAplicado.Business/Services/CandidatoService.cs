using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Interfaces.Services;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Business.Services
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public async Task<bool> Adicionar(Candidato candidato)
        {
            await _candidatoRepository.Adicionar(candidato);
            return true;
        }
    }
}
