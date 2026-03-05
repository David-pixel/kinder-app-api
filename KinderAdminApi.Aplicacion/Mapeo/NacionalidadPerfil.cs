using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class NacionalidadPerfil : Profile
    {
        public NacionalidadPerfil()
        {
            CreateMap<Nacionalidad, NacionalidadDto>().ReverseMap();
        }
    }
}