using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;

namespace KinderAdminApi.Aplicacion.Servicios
{
    public interface IServicioCatalogos
    {
        Task<RespuestaGenerica<IEnumerable<ProvinciaDto>>> ObtenerProvinciasAsync(short? codigoProvincia = null);
        Task<RespuestaGenerica<IEnumerable<CantonDto>>> ObtenerCantonesAsync(short? codigoProvincia = null, short? codigoCanton = null);
        Task<RespuestaGenerica<IEnumerable<DistritoDto>>> ObtenerDistritosAsync(short? codigoCanton = null, int? codigoDistrito = null);
        Task<RespuestaGenerica<IEnumerable<EstadoAsistenciaDto>>> ObtenerEstadosAsistenciaAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<EstadoCivilDto>>> ObtenerEstadosCivilesAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<EstadoMatriculaDto>>> ObtenerEstadosMatriculaAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<GeneroDto>>> ObtenerGenerosAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<GrupoEscolarDto>>> ObtenerGruposEscolaresAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<IdiomaDto>>> ObtenerIdiomasAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<NacionalidadDto>>> ObtenerNacionalidadesAsync(short? id = null, string? codigoIso = null);
        Task<RespuestaGenerica<IEnumerable<NivelEducativoDto>>> ObtenerNivelesEducativosAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<OcupacionDto>>> ObtenerOcupacionesAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<RazonAusenciaDto>>> ObtenerRazonesAusenciaAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<RolDto>>> ObtenerRolesAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<RolAulaDto>>> ObtenerRolesAulaAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<TipoEstudianteDto>>> ObtenerTiposEstudianteAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<TipoHorarioDto>>> ObtenerTiposHorarioAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<TipoIdentificacionDto>>> ObtenerTiposIdentificacionAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<TipoRelacionDto>>> ObtenerTiposRelacionAsync(short? id = null, string? codigo = null);
        Task<RespuestaGenerica<IEnumerable<TipoSangreDto>>> ObtenerTiposSangreAsync(short? id = null, string? codigo = null);
    }
}
