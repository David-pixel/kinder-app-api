using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class IdiomaPerfil : Profile
    {
        public IdiomaPerfil()
        {
            CreateMap<Idioma, IdiomaDto>().ReverseMap();
        }
    }
}