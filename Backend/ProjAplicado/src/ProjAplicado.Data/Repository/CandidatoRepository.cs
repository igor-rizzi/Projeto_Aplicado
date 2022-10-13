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
    public class CandidatoRepository : Repository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(ApiDbContext context) : base(context) { }
    }
}
