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
    public class UsuarioEmpresaController : ControllerBase
    {
        private readonly IUsuarioEmpresaRepository _usuarioEmpresaRepository;
        private readonly IUsuarioEmpresaService _usuarioEmpresaService;
        private readonly IMapper _mapper;
        private readonly ApiDbContext _dbContext;

        public UsuarioEmpresaController(IUsuarioEmpresaRepository usuarioEmpresaRepository, 
                                        IUsuarioEmpresaService usuarioEmpresaService, 
                                        IMapper mapper, 
                                        ApiDbContext dbContext)
        {
            _usuarioEmpresaRepository = usuarioEmpresaRepository;
            _usuarioEmpresaService = usuarioEmpresaService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioEmpresaDto>> Adicionar(UsuarioEmpresaDto usuarioEmpresaDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = _mapper.Map<UsuarioEmpresa>(usuarioEmpresaDto);
            await _usuarioEmpresaService.Adicionar(user);

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioEmpresaDto>> ObterTodos()
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioEmpresaDto>>(await _usuarioEmpresaRepository.ObterTodos());
            return usuarios;
        }

        [HttpGet("{id:Guid}")]
        public async Task<UsuarioEmpresaDto> ObterPorId(Guid id)
        {
            var usuario = _mapper.Map<UsuarioEmpresaDto>(await _usuarioEmpresaRepository.ObterPorId(id));

            return usuario;
        }

    }
}
