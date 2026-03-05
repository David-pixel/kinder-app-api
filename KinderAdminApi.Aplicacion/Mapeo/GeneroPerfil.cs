using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class GeneroPerfil : Profile
    {
        public GeneroPerfil()
        {
            CreateMap<Genero, GeneroDto>().ReverseMap();
        }
    }
}