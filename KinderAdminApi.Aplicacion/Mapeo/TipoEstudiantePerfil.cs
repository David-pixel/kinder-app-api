using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class TipoEstudiantePerfil : Profile
    {
        public TipoEstudiantePerfil()
        {
            CreateMap<TipoEstudiante, TipoEstudianteDto>().ReverseMap();
        }
    }
}