using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class DistritoPerfil : Profile
    {
        public DistritoPerfil()
        {
            CreateMap<Distrito, DistritoDto>().ReverseMap();
        }
    }
}