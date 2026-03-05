using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Extensiones;
using KinderAdminApi.Compartido.Repuestas;
using KinderAdminApi.Dominio.Interfaces;

namespace KinderAdminApi.Aplicacion.Servicios
{
    public sealed class ServicioCatalogos : IServicioCatalogos
    {
        private readonly IRepositorioCatalogos _repositorio;
        private readonly IMapper _mapper;

        public ServicioCatalogos(IRepositorioCatalogos repositorio,IMapper mapper)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        /// <summary>
        /// Obtiene el catálogo de provincias.
        /// </summary>
        /// <param name="codigoProvincia">Código de provincia opcional para filtrar. Si es nulo, devuelve todas.</param>
        /// <returns>Lista de provincias en formato DTO.</returns>
        public async Task<RespuestaGenerica<IEnumerable<ProvinciaDto>>> ObtenerProvinciasAsync(short? codigoProvincia = null)
        {
            var provincias = await _repositorio.ObtenerProvinciasAsync(codigoProvincia);

            if (!provincias.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron provincias.");

            var datos = _mapper.Map<IEnumerable<ProvinciaDto>>(provincias);
            return RespuestaGenerica<IEnumerable<ProvinciaDto>>.Exito(datos, "Provincias obtenidas correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<CantonDto>>> ObtenerCantonesAsync(short? codigoProvincia = null, short? codigoCanton = null)
        {
            var cantones = await _repositorio.ObtenerCantonesAsync(codigoProvincia, codigoCanton);

            if (!cantones.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron cantones.");

            var datos = _mapper.Map<IEnumerable<CantonDto>>(cantones);
            return RespuestaGenerica<IEnumerable<CantonDto>>.Exito(datos, "Cantones obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<DistritoDto>>> ObtenerDistritosAsync(short? codigoCanton = null, int? codigoDistrito = null)
        {
            var distritos = await _repositorio.ObtenerDistritosAsync(codigoCanton, codigoDistrito);

            if (!distritos.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron distritos.");

            var datos = _mapper.Map<IEnumerable<DistritoDto>>(distritos);
            return RespuestaGenerica<IEnumerable<DistritoDto>>.Exito(datos, "Distritos obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<EstadoAsistenciaDto>>> ObtenerEstadosAsistenciaAsync(short? id = null, string? codigo = null)
        {
            var estados = await _repositorio.ObtenerEstadosAsistenciaAsync(id, codigo);

            if (!estados.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron estados de asistencia.");

            var datos = _mapper.Map<IEnumerable<EstadoAsistenciaDto>>(estados);
            return RespuestaGenerica<IEnumerable<EstadoAsistenciaDto>>.Exito(datos, "Estados de asistencia obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<EstadoCivilDto>>> ObtenerEstadosCivilesAsync(short? id = null, string? codigo = null)
        {
            var estados = await _repositorio.ObtenerEstadosCivilesAsync(id, codigo);

            if (!estados.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron estados civiles.");

            var datos = _mapper.Map<IEnumerable<EstadoCivilDto>>(estados);
            return RespuestaGenerica<IEnumerable<EstadoCivilDto>>.Exito(datos, "Estados civiles obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<EstadoMatriculaDto>>> ObtenerEstadosMatriculaAsync(short? id = null, string? codigo = null)
        {
            var estados = await _repositorio.ObtenerEstadosMatriculaAsync(id, codigo);

            if (!estados.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron estados de matrícula.");

            var datos = _mapper.Map<IEnumerable<EstadoMatriculaDto>>(estados);
            return RespuestaGenerica<IEnumerable<EstadoMatriculaDto>>.Exito(datos, "Estados de matrícula obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<GeneroDto>>> ObtenerGenerosAsync(short? id = null, string? codigo = null)
        {
            var generos = await _repositorio.ObtenerGenerosAsync(id, codigo);

            if (!generos.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron géneros.");

            var datos = _mapper.Map<IEnumerable<GeneroDto>>(generos);
            return RespuestaGenerica<IEnumerable<GeneroDto>>.Exito(datos, "Géneros obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<GrupoEscolarDto>>> ObtenerGruposEscolaresAsync(short? id = null, string? codigo = null)
        {
            var grupos = await _repositorio.ObtenerGruposEscolaresAsync(id, codigo);

            if (!grupos.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron grupos escolares.");

            var datos = _mapper.Map<IEnumerable<GrupoEscolarDto>>(grupos);
            return RespuestaGenerica<IEnumerable<GrupoEscolarDto>>.Exito(datos, "Grupos escolares obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<IdiomaDto>>> ObtenerIdiomasAsync(short? id = null, string? codigo = null)
        {
            var idiomas = await _repositorio.ObtenerIdiomasAsync(id, codigo);

            if (!idiomas.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron idiomas.");

            var datos = _mapper.Map<IEnumerable<IdiomaDto>>(idiomas);
            return RespuestaGenerica<IEnumerable<IdiomaDto>>.Exito(datos, "Idiomas obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<NacionalidadDto>>> ObtenerNacionalidadesAsync(short? id = null, string? codigoIso = null)
        {
            var nacionalidades = await _repositorio.ObtenerNacionalidadesAsync(id, codigoIso);

            if (!nacionalidades.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron nacionalidades.");

            var datos = _mapper.Map<IEnumerable<NacionalidadDto>>(nacionalidades);
            return RespuestaGenerica<IEnumerable<NacionalidadDto>>.Exito(datos, "Nacionalidades obtenidas correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<NivelEducativoDto>>> ObtenerNivelesEducativosAsync(short? id = null, string? codigo = null)
        {
            var niveles = await _repositorio.ObtenerNivelesEducativosAsync(id, codigo);

            if (!niveles.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron niveles educativos.");

            var datos = _mapper.Map<IEnumerable<NivelEducativoDto>>(niveles);
            return RespuestaGenerica<IEnumerable<NivelEducativoDto>>.Exito(datos, "Niveles educativos obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<OcupacionDto>>> ObtenerOcupacionesAsync(short? id = null, string? codigo = null)
        {
            var ocupaciones = await _repositorio.ObtenerOcupacionesAsync(id, codigo);

            if (!ocupaciones.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron ocupaciones.");

            var datos = _mapper.Map<IEnumerable<OcupacionDto>>(ocupaciones);
            return RespuestaGenerica<IEnumerable<OcupacionDto>>.Exito(datos, "Ocupaciones obtenidas correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<RazonAusenciaDto>>> ObtenerRazonesAusenciaAsync(short? id = null, string? codigo = null)
        {
            var razones = await _repositorio.ObtenerRazonesAusenciaAsync(id, codigo);

            if (!razones.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron razones de ausencia.");

            var datos = _mapper.Map<IEnumerable<RazonAusenciaDto>>(razones);
            return RespuestaGenerica<IEnumerable<RazonAusenciaDto>>.Exito(datos, "Razones de ausencia obtenidas correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<RolDto>>> ObtenerRolesAsync(short? id = null, string? codigo = null)
        {
            var roles = await _repositorio.ObtenerRolesAsync(id, codigo);

            if (!roles.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron roles.");

            var datos = _mapper.Map<IEnumerable<RolDto>>(roles);
            return RespuestaGenerica<IEnumerable<RolDto>>.Exito(datos, "Roles obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<RolAulaDto>>> ObtenerRolesAulaAsync(short? id = null, string? codigo = null)
        {
            var roles = await _repositorio.ObtenerRolesAulaAsync(id, codigo);

            if (!roles.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron roles de aula.");

            var datos = _mapper.Map<IEnumerable<RolAulaDto>>(roles);
            return RespuestaGenerica<IEnumerable<RolAulaDto>>.Exito(datos, "Roles de aula obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<TipoEstudianteDto>>> ObtenerTiposEstudianteAsync(short? id = null, string? codigo = null)
        {
            var tipos = await _repositorio.ObtenerTiposEstudianteAsync(id, codigo);

            if (!tipos.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron tipos de estudiante.");

            var datos = _mapper.Map<IEnumerable<TipoEstudianteDto>>(tipos);
            return RespuestaGenerica<IEnumerable<TipoEstudianteDto>>.Exito(datos, "Tipos de estudiante obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<TipoHorarioDto>>> ObtenerTiposHorarioAsync(short? id = null, string? codigo = null)
        {
            var tipos = await _repositorio.ObtenerTiposHorarioAsync(id, codigo);

            if (!tipos.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron tipos de horario.");

            var datos = _mapper.Map<IEnumerable<TipoHorarioDto>>(tipos);
            return RespuestaGenerica<IEnumerable<TipoHorarioDto>>.Exito(datos, "Tipos de horario obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<TipoIdentificacionDto>>> ObtenerTiposIdentificacionAsync(short? id = null, string? codigo = null)
        {
            var tipos = await _repositorio.ObtenerTiposIdentificacionAsync(id, codigo);

            if (!tipos.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron tipos de identificación.");

            var datos = _mapper.Map<IEnumerable<TipoIdentificacionDto>>(tipos);
            return RespuestaGenerica<IEnumerable<TipoIdentificacionDto>>.Exito(datos, "Tipos de identificación obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<TipoRelacionDto>>> ObtenerTiposRelacionAsync(short? id = null, string? codigo = null)
        {
            var tipos = await _repositorio.ObtenerTiposRelacionAsync(id, codigo);

            if (!tipos.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron tipos de relación.");

            var datos = _mapper.Map<IEnumerable<TipoRelacionDto>>(tipos);
            return RespuestaGenerica<IEnumerable<TipoRelacionDto>>.Exito(datos, "Tipos de relación obtenidos correctamente.");
        }

        public async Task<RespuestaGenerica<IEnumerable<TipoSangreDto>>> ObtenerTiposSangreAsync(short? id = null, string? codigo = null)
        {
            var tipos = await _repositorio.ObtenerTiposSangreAsync(id, codigo);

            if (!tipos.Any())
                throw new NoEncontradoException(
                    CodigosError.CatalogoNoEncontrado,
                    "No se encontraron tipos de sangre.");

            var datos = _mapper.Map<IEnumerable<TipoSangreDto>>(tipos);
            return RespuestaGenerica<IEnumerable<TipoSangreDto>>.Exito(datos, "Tipos de sangre obtenidos correctamente.");
        }
    }
}
