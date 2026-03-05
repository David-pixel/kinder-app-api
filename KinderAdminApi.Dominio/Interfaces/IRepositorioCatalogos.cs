using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Dominio.Interfaces
{
    public interface IRepositorioCatalogos
    {
        Task<IEnumerable<Provincia>> ObtenerProvinciasAsync(short? codigoProvincia = null);
        Task<IEnumerable<Canton>> ObtenerCantonesAsync(short? codigoProvincia = null, short? codigoCanton = null);
        Task<IEnumerable<Distrito>> ObtenerDistritosAsync(short? codigoCanton = null, int? codigoDistrito = null);
        Task<IEnumerable<EstadoAsistencia>> ObtenerEstadosAsistenciaAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<EstadoCivil>> ObtenerEstadosCivilesAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<EstadoMatricula>> ObtenerEstadosMatriculaAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<Genero>> ObtenerGenerosAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<GrupoEscolar>> ObtenerGruposEscolaresAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<Idioma>> ObtenerIdiomasAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<Nacionalidad>> ObtenerNacionalidadesAsync(short? id = null, string? codigoIso = null);
        Task<IEnumerable<NivelEducativo>> ObtenerNivelesEducativosAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<Ocupacion>> ObtenerOcupacionesAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<RazonAusencia>> ObtenerRazonesAusenciaAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<Rol>> ObtenerRolesAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<RolAula>> ObtenerRolesAulaAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<TipoEstudiante>> ObtenerTiposEstudianteAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<TipoHorario>> ObtenerTiposHorarioAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<TipoIdentificacion>> ObtenerTiposIdentificacionAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<TipoRelacion>> ObtenerTiposRelacionAsync(short? id = null, string? codigo = null);
        Task<IEnumerable<TipoSangre>> ObtenerTiposSangreAsync(short? id = null, string? codigo = null);
    }
}