using API.ApplicationCore.DTOs;
using API.ApplicationCore.Entities;
using AutoMapper;

namespace API.Configurations
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Veiculo,VeiculoDTO>().ReverseMap();
            CreateMap<Administrador,AdministradorDTO>().ReverseMap();
        }
    }
}
