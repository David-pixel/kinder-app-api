using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class NivelEducativoPerfil : Profile
    {
        public NivelEducativoPerfil()
        {
            CreateMap<NivelEducativo, NivelEducativoDto>().ReverseMap();
        }
    }
}