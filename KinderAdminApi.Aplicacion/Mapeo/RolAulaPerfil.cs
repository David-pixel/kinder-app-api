using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class RolAulaPerfil : Profile
    {
        public RolAulaPerfil()
        {
            CreateMap<RolAula, RolAulaDto>().ReverseMap();
        }
    }
}