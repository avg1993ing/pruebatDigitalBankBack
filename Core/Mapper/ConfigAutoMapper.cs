using AutoMapper;
using Core.DTO;
using Core.Entities;

namespace Core.Mapper
{
    public class ConfigAutoMapper : Profile
    {
        public ConfigAutoMapper()
        {
            CreateMap<Usuarios, UsuariosDto>().ReverseMap();
        }
    }
}
