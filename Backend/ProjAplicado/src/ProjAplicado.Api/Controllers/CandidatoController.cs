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
    public class CandidatoController : MainController
    {
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly ICandidatoService _candidatoService;
        private readonly IMapper _mapper;
        private readonly ApiDbContext _dbContext;

        public CandidatoController(
            ICandidatoRepository candidatoRepository, 
            ICandidatoService candidatoService, 
            IMapper mapper, 
            ApiDbContext dbContext,
            INotificador notificador): base(notificador)
        {
            _candidatoRepository = candidatoRepository;
            _candidatoService = candidatoService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<CandidatoDto>> Adicionar(CandidatoDto candidatoDto)
        {
            if (!ModelState.IsValid) return CustomReponse(ModelState);

            var user = _mapper.Map<Candidato>(candidatoDto);
            await _candidatoService.Adicionar(user);

            _dbContext.SaveChanges();

            return CustomResponse(candidatoDto);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CandidatoDto>> ObterTodos()
        {
            var candidatos = _mapper.Map<IEnumerable<CandidatoDto>>(await _candidatoRepository.ObterTodos());

            return candidatos;
        }
    }
}
