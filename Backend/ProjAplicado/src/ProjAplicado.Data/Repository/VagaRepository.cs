using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Models;
using ProjAplicado.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAplicado.Data.Repository
{
    public class VagaRepository : Repository<Vaga>, IVagaRepository
    {
        public VagaRepository(ApiDbContext context) : base(context) { }
    }
}
