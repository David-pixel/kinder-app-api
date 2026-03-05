using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class TipoIdentificacionPerfil : Profile
    {
        public TipoIdentificacionPerfil()
        {
            CreateMap<TipoIdentificacion, TipoIdentificacionDto>().ReverseMap();
        }
    }
}