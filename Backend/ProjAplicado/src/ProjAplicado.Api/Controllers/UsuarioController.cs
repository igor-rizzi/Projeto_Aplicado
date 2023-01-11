using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjAplicado.Api.Dtos;
using ProjAplicado.Business.Intefaces.Notification;
using ProjAplicado.Business.Interfaces.Repositories;
using ProjAplicado.Business.Interfaces.Services;
using ProjAplicado.Business.Models;
using ProjAplicado.Data.Context;

namespace ProjAplicado.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly ApiDbContext _dbContext;

        public UsuarioController(
            IUsuarioRepository usuarioRepository,
            IUsuarioService usuarioService,
            IMapper mapper,
            ApiDbContext dbContext,
            INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Adicionar(UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioService.Adicionar(user);

            _dbContext.SaveChanges();

            return CustomResponse(usuarioDto);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<UsuarioDto>> ObterTodos()
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioDto>>(await _usuarioRepository.ObterTodos());

            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<UsuarioDto> ObterPorId(int id)
        {
            var usuario = _mapper.Map<UsuarioDto>(await _usuarioRepository.ObterPorId(id));

            return usuario;
        }
    }
}
