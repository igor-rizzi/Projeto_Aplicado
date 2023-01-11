using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjAplicado.Api.Dtos;
using ProjAplicado.Business.Intefaces.Notification;
using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Interfaces.Services;
using ProjAplicado.Business.Models;
using ProjAplicado.Business.Services;
using ProjAplicado.Data.Context;
using ProjAplicado.Data.Repository;

namespace ProjAplicado.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : MainController
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;
        private readonly ApiDbContext _dbContext;

        public EmpresaController(
            IEmpresaRepository empresaRepository, 
            IEmpresaService empresaService, 
            IMapper mapper, 
            ApiDbContext dbContext,
            INotificador notificador) : base(notificador)
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

            return CustomResponse(empresaDto);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EmpresaDto>> ObterTodos()
        {
            var empresas = _mapper.Map<IEnumerable<EmpresaDto>>(await _empresaRepository.ObterTodos());

            return empresas;
        }
    }
}
