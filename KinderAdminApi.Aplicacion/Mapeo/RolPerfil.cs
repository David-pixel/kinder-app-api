using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class RolPerfil : Profile
    {
        public RolPerfil()
        {
            CreateMap<Rol, RolDto>().ReverseMap();
        }
    }
}