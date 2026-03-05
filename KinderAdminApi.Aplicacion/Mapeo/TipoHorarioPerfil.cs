using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class TipoHorarioPerfil : Profile
    {
        public TipoHorarioPerfil()
        {
            CreateMap<TipoHorario, TipoHorarioDto>().ReverseMap();
        }
    }
}