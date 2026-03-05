using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class GrupoEscolarPerfil : Profile
    {
        public GrupoEscolarPerfil()
        {
            CreateMap<GrupoEscolar, GrupoEscolarDto>().ReverseMap();
        }
    }
}