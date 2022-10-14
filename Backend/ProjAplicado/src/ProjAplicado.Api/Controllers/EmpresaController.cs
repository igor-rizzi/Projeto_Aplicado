using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjAplicado.Api.Dtos;
using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Interfaces.Services;
using ProjAplicado.Business.Models;
using ProjAplicado.Business.Services;
using ProjAplicado.Data.Context;
using ProjAplicado.Data.Repository;

namespace ProjAplicado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;
        private readonly ApiDbContext _dbContext;

        public CandidatoController(
            IEmpresaRepository empresaRepository, 
            IEmpresaService empresaService, 
            IMapper mapper, ApiDbContext dbContext)
        {
            _empresaRepository = empresaRepository;
            _empresaService = empresaService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaDto>> Adicionar(EmpresaDto empresaDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = _mapper.Map<Empresa>(empresaDto);
            await _empresaService.Adicionar(user);

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<EmpresaDto>> ObterTodos()
        {
            var empresas = _mapper.Map<IEnumerable<EmpresaDto>>(await _empresaRepository.ObterTodos());

            return empresas;
        }
    }
}
