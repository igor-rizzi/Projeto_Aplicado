using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Models;
using ProjAplicado.Data.Context;

namespace ProjAplicado.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApiDbContext context) : base(context) { }
    }
}