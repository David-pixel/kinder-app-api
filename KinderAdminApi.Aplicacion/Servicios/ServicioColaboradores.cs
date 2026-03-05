using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Extensiones;
using KinderAdminApi.Compartido.Repuestas;
using KinderAdminApi.Dominio.Entidades;
using KinderAdminApi.Dominio.Interfaces;

namespace KinderAdminApi.Aplicacion.Servicios
{
    public sealed class ServicioColaboradores : IServicioColaboradores
    {
        private readonly IRepositorioColaboradores _repositorio;
        private readonly IMapper _mapper;

        public ServicioColaboradores(IRepositorioColaboradores repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;

        }

        public async Task<RespuestaGenerica<IEnumerable<ColaboradorDto>>> ObtenerColaboradoresAsync(bool? activo = null)
        {
            var colaboradores = await _repositorio.ObtenerColaboradoresAsync(activo);

            if (!colaboradores.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron colaboradores.");

            var datos = _mapper.Map<IEnumerable<ColaboradorDto>>(colaboradores);
            return RespuestaGenerica<IEnumerable<ColaboradorDto>>.Exito(datos, "Colaboradores obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<ColaboradorCreadoDto>> CrearColaboradorAsync(CrearColaboradorDto dto)
        {


            var entidad = _mapper.Map<CrearColaborador>(dto);
            var creado = await _repositorio.CrearColaboradorAsync(entidad);
            var resultado = _mapper.Map<ColaboradorCreadoDto>(creado);
            return RespuestaGenerica<ColaboradorCreadoDto>.Exito(resultado, "Colaborador creado correctamente.");


        }
    }
}