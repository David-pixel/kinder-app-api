using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class EstadoMatriculaPerfil : Profile
    {
        public EstadoMatriculaPerfil()
        {
            CreateMap<EstadoMatricula, EstadoMatriculaDto>().ReverseMap();
        }
    }
}