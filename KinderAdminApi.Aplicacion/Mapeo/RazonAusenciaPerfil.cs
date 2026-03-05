using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class RazonAusenciaPerfil : Profile
    {
        public RazonAusenciaPerfil()
        {
            CreateMap<RazonAusencia, RazonAusenciaDto>().ReverseMap();
        }
    }
}