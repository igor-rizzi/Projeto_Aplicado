using AutoMapper;
using ProjAplicado.Api.Dtos;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
