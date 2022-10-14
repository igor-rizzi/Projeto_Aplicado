namespace ProjAplicado.Business.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<bool> Adicionar(Empresa empresa)
        {
            await _empresaRepository.Adicionar(empresa);
            return true;
        }
    }
}