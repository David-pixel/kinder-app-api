using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Aplicacion.Mapeo
{
    public sealed class ColaboradorPerfil : Profile
    {
        public ColaboradorPerfil()
        {
            CreateMap<Colaborador, ColaboradorDto>().ReverseMap();
            CreateMap<ColaboradorCreado, ColaboradorCreadoDto>();
            CreateMap<CrearColaboradorDto, CrearColaborador>();
        }
    }
}