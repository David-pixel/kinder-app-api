
using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;
namespace KinderAdminApi.Aplicacion.Mapeo
{  /// <summary>
   /// Perfil de AutoMapper encargado de mapear la entidad de provincia con su DTO.
   /// </summary>
    public sealed class ProvinciaPerfil : Profile
    {
        public ProvinciaPerfil()
        {
            CreateMap<Provincia, ProvinciaDto>().ReverseMap();
        }
    }
}
