using ProjAplicado.Business.Models;

namespace ProjAplicado.Business.Interfaces.Services
{
    public interface IEmpresaService
    {
        Task<bool> Adicionar(Empresa empresa);
    }
}
