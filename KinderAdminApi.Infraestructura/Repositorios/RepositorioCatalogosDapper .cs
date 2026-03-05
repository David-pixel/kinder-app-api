using Dapper;
using KinderAdminApi.Compartido.Extensiones;
using KinderAdminApi.Compartido.Repuestas;
using KinderAdminApi.Dominio.Entidades;
using KinderAdminApi.Dominio.Interfaces;
using KinderAdminApi.Infraestructura.Db;

namespace KinderAdminApi.Infraestructura.Repositorios
{
    public sealed class RepositorioCatalogosDapper : IRepositorioCatalogos
    {
        private readonly IFabricaConexionDb _fabrica;

        public RepositorioCatalogosDapper(IFabricaConexionDb fabrica)
        {
            _fabrica = fabrica;
        }

        public async Task<IEnumerable<Provincia>> ObtenerProvinciasAsync(short? codigoProvincia = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT codigo_provincia,
                            nombre,
                            activo
                     FROM fn_obtener_cat_provincias(@p_codigo_provincia);";

            return await conexion.QueryAsync<Provincia>(sql, new
            {
                p_codigo_provincia = codigoProvincia
            });
        }

        public async Task<IEnumerable<Canton>> ObtenerCantonesAsync(short? codigoProvincia = null, short? codigoCanton = null)
        {
            using var conexion = _fabrica.CrearConexion();
            const string sql = @"SELECT codigo_canton,
                            codigo_provincia,
                            nombre,
                            activo
                     FROM fn_obtener_cat_cantones(@p_codigo_provincia, @p_codigo_canton);";

            return await conexion.QueryAsync<Canton>(sql, new
            {
                p_codigo_provincia = codigoProvincia,
                p_codigo_canton = codigoCanton
            });
        }

        public async Task<IEnumerable<Distrito>> ObtenerDistritosAsync(short? codigoCanton = null, int? codigoDistrito = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT codigo_distrito,
                                   codigo_canton,
                                   nombre,
                                   activo
                              FROM fn_obtener_cat_distritos(@p_codigo_canton, @p_codigo_distrito);";

            return await conexion.QueryAsync<Distrito>(sql, new
            {
                p_codigo_canton = codigoCanton,
                p_codigo_distrito = codigoDistrito
            });
        }

        public async Task<IEnumerable<EstadoAsistencia>> ObtenerEstadosAsistenciaAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_estados_asistencia(@p_id, @p_codigo);";

            return await conexion.QueryAsync<EstadoAsistencia>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<EstadoCivil>> ObtenerEstadosCivilesAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_estados_civiles(@p_id, @p_codigo);";

            return await conexion.QueryAsync<EstadoCivil>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<EstadoMatricula>> ObtenerEstadosMatriculaAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_estados_matricula(@p_id, @p_codigo);";

            return await conexion.QueryAsync<EstadoMatricula>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<Genero>> ObtenerGenerosAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_generos(@p_id, @p_codigo);";

            return await conexion.QueryAsync<Genero>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<GrupoEscolar>> ObtenerGruposEscolaresAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        edad_minima_meses,
                                        edad_maxima_meses,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_grupos_escolares(@p_id, @p_codigo);";

            return await conexion.QueryAsync<GrupoEscolar>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<Idioma>> ObtenerIdiomasAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_idiomas(@p_id, @p_codigo);";

            return await conexion.QueryAsync<Idioma>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<Nacionalidad>> ObtenerNacionalidadesAsync(short? id = null, string? codigoIso = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo_iso,
                                        nombre,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_nacionalidades(@p_id, @p_codigo_iso);";

            return await conexion.QueryAsync<Nacionalidad>(sql, new
            {
                p_id = id,
                p_codigo_iso = codigoIso
            });
        }

        public async Task<IEnumerable<NivelEducativo>> ObtenerNivelesEducativosAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_niveles_educativos(@p_id, @p_codigo);";

            return await conexion.QueryAsync<NivelEducativo>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<Ocupacion>> ObtenerOcupacionesAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_ocupaciones(@p_id, @p_codigo);";

            return await conexion.QueryAsync<Ocupacion>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<RazonAusencia>> ObtenerRazonesAusenciaAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_razones_ausencia(@p_id, @p_codigo);";

            return await conexion.QueryAsync<RazonAusencia>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<Rol>> ObtenerRolesAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_roles(@p_id, @p_codigo);";

            return await conexion.QueryAsync<Rol>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<RolAula>> ObtenerRolesAulaAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        descripcion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_roles_aula(@p_id, @p_codigo);";

            return await conexion.QueryAsync<RolAula>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<TipoEstudiante>> ObtenerTiposEstudianteAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        descripcion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_tipos_estudiante(@p_id, @p_codigo);";

            return await conexion.QueryAsync<TipoEstudiante>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<TipoHorario>> ObtenerTiposHorarioAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        descripcion,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_tipos_horario(@p_id, @p_codigo);";

            return await conexion.QueryAsync<TipoHorario>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<TipoIdentificacion>> ObtenerTiposIdentificacionAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        mascara,
                                        regex,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_tipos_identificacion(@p_id, @p_codigo);";

            return await conexion.QueryAsync<TipoIdentificacion>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<TipoRelacion>> ObtenerTiposRelacionAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_tipos_relacion(@p_id, @p_codigo);";

            return await conexion.QueryAsync<TipoRelacion>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }

        public async Task<IEnumerable<TipoSangre>> ObtenerTiposSangreAsync(short? id = null, string? codigo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id,
                                        codigo,
                                        nombre,
                                        orden_visualizacion,
                                        activo,
                                        creado_en
                                   FROM fn_obtener_cat_tipos_sangre(@p_id, @p_codigo);";

            return await conexion.QueryAsync<TipoSangre>(sql, new
            {
                p_id = id,
                p_codigo = codigo
            });
        }
    }
}
