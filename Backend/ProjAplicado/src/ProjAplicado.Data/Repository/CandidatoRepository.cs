using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Models;
using ProjAplicado.Data.Context;

namespace ProjAplicado.Data.Repository
{
    public class CandidatoRepository : Repository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(ApiDbContext context) : base(context) { }
    }
}
