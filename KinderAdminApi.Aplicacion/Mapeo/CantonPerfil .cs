using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class CantonPerfil : Profile
    {
        public CantonPerfil()
        {
            CreateMap<Canton, CantonDto>().ReverseMap();
        }
    }
}
