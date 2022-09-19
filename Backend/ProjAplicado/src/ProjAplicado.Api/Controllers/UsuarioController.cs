using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjAplicado.Api.Dtos;
using ProjAplicado.Business.Interfaces;
using ProjAplicado.Business.Models;
using ProjAplicado.Data.Context;

namespace ProjAplicado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly ApiDbContext _dbContext;

        public UsuarioController(
            IUsuarioRepository usuarioRepository, 
            IUsuarioService usuarioService,
            IMapper mapper,
            ApiDbContext dbContext)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Adicionar(UsuarioDto usuarioDto)
        {
            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioDto));

            _dbContext.SaveChanges();

            return Ok(usuarioDto);
        }
    }
}
