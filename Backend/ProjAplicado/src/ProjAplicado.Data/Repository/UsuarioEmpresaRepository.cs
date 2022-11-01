using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Models;
using ProjAplicado.Data.Context;

namespace ProjAplicado.Data.Repository
{
    public class UsuarioEmpresaRepository : Repository<UsuarioEmpresa>, IUsuarioEmpresaRepository
    {
        public UsuarioEmpresaRepository(ApiDbContext db) : base(db){}
    }
}
