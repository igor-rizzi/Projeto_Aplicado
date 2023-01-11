using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjAplicado.Api.Dtos;
using ProjAplicado.Business.Intefaces.Notification;
using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Interfaces.Services;
using ProjAplicado.Business.Models;
using ProjAplicado.Data.Context;

namespace ProjAplicado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagaController : MainController
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IVagaService _vagaService;
        private readonly IMapper _mapper;
        private readonly ApiDbContext _dbContext;

        public VagaController(IVagaRepository vagaRepository, 
                              IVagaService vagaService, 
                              IMapper mapper, 
                              ApiDbContext dbContext,
                              INotificador notificador) : base(notificador)
        {
            _vagaRepository = vagaRepository;
            _vagaService = vagaService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<VagaDto>> Adicionar(VagaDto vagaDto)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var vaga = _mapper.Map<Vaga>(vagaDto);
            await _vagaService.Adicionar(vaga);

            _dbContext.SaveChanges();

            return CustomResponse(vagaDto);
        }

        [HttpGet]
        public async Task<IEnumerable<VagaDto>> ObterTodos()
        {
            var vagas = _mapper.Map<IEnumerable<VagaDto>>(await _vagaRepository.ObterTodos());

            return vagas;
        }

        [HttpGet("{id}")]
        public async Task<VagaDto> ObterPorId(int id)
        {
            var vaga = _mapper.Map<VagaDto>(await _vagaRepository.ObterPorId(id));

            return vaga;
        }
    }
}
