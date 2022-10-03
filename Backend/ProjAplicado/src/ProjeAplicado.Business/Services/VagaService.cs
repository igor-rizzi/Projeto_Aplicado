using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Interfaces.Services;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Business.Services
{
    public class VagaService : IVagaService
    {
        private readonly IVagaRepository _vagaRepository;
        public VagaService(IVagaRepository vagaRepository)
        {
            _vagaRepository = vagaRepository;
        }

        public async Task<bool> Adicionar(Vaga vaga)
        {
            await _vagaRepository.Adicionar(vaga);

            return true;
        }
    }
}
