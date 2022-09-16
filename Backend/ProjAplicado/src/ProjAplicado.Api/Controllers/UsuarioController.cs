using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjAplicado.Api.Dtos;
using ProjAplicado.Business.Interfaces;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(
            IUsuarioRepository usuarioRepository, 
            IUsuarioService usuarioService,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Adicionar(UsuarioDto usuarioDto)
        {
            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioDto));

            return Ok(usuarioDto);
        }
    }
}
