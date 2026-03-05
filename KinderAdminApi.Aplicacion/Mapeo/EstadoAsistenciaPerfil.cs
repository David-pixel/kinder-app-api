using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class EstadoAsistenciaPerfil : Profile
    {
        public EstadoAsistenciaPerfil()
        {
            CreateMap<EstadoAsistencia, EstadoAsistenciaDto>().ReverseMap();
        }
    }
}