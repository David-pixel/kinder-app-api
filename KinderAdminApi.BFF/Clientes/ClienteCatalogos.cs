using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;

namespace KinderAPP.BFF.Clients
{
    public sealed class ClienteCatalogos
    {
        private readonly HttpClient _http;

        public ClienteCatalogos(HttpClient http) => _http = http;

        private async Task<T?> ObtenerAsync<T>(string url)
        {
            var respuesta = await _http.GetAsync(url);
            return await respuesta.Content.ReadFromJsonAsync<T>();
        }

        public Task<RespuestaGenerica<IEnumerable<ProvinciaDto>>?> ObtenerProvinciasAsync(short? codigoProvincia = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<ProvinciaDto>>>($"api/catalogo/provincias{(codigoProvincia.HasValue ? $"?codigoProvincia={codigoProvincia}" : "")}");

        public Task<RespuestaGenerica<IEnumerable<CantonDto>>?> ObtenerCantonesAsync(short? codigoProvincia = null, short? codigoCanton = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<CantonDto>>>($"api/catalogo/cantones{BuildQuery(("codigoProvincia", codigoProvincia), ("codigoCanton", codigoCanton))}");

        public Task<RespuestaGenerica<IEnumerable<DistritoDto>>?> ObtenerDistritosAsync(short? codigoCanton = null, int? codigoDistrito = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<DistritoDto>>>($"api/catalogo/distritos{BuildQuery(("codigoCanton", codigoCanton), ("codigoDistrito", codigoDistrito))}");

        public Task<RespuestaGenerica<IEnumerable<EstadoAsistenciaDto>>?> ObtenerEstadosAsistenciaAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<EstadoAsistenciaDto>>>($"api/catalogo/estados-asistencia{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<EstadoCivilDto>>?> ObtenerEstadosCivilesAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<EstadoCivilDto>>>($"api/catalogo/estados-civiles{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<EstadoMatriculaDto>>?> ObtenerEstadosMatriculaAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<EstadoMatriculaDto>>>($"api/catalogo/estados-matricula{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<GeneroDto>>?> ObtenerGenerosAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<GeneroDto>>>($"api/catalogo/generos{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<GrupoEscolarDto>>?> ObtenerGruposEscolaresAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<GrupoEscolarDto>>>($"api/catalogo/grupos-escolares{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<IdiomaDto>>?> ObtenerIdiomasAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<IdiomaDto>>>($"api/catalogo/idiomas{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<NacionalidadDto>>?> ObtenerNacionalidadesAsync(short? id = null, string? codigoIso = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<NacionalidadDto>>>($"api/catalogo/nacionalidades{BuildQuery(("id", id), ("codigoIso", codigoIso))}");

        public Task<RespuestaGenerica<IEnumerable<NivelEducativoDto>>?> ObtenerNivelesEducativosAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<NivelEducativoDto>>>($"api/catalogo/niveles-educativos{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<OcupacionDto>>?> ObtenerOcupacionesAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<OcupacionDto>>>($"api/catalogo/ocupaciones{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<RazonAusenciaDto>>?> ObtenerRazonesAusenciaAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<RazonAusenciaDto>>>($"api/catalogo/razones-ausencia{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<RolDto>>?> ObtenerRolesAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<RolDto>>>($"api/catalogo/roles{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<RolAulaDto>>?> ObtenerRolesAulaAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<RolAulaDto>>>($"api/catalogo/roles-aula{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<TipoEstudianteDto>>?> ObtenerTiposEstudianteAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<TipoEstudianteDto>>>($"api/catalogo/tipos-estudiante{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<TipoHorarioDto>>?> ObtenerTiposHorarioAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<TipoHorarioDto>>>($"api/catalogo/tipos-horario{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<TipoIdentificacionDto>>?> ObtenerTiposIdentificacionAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<TipoIdentificacionDto>>>($"api/catalogo/tipos-identificacion{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<TipoRelacionDto>>?> ObtenerTiposRelacionAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<TipoRelacionDto>>>($"api/catalogo/tipos-relacion{BuildQuery(("id", id), ("codigo", codigo))}");

        public Task<RespuestaGenerica<IEnumerable<TipoSangreDto>>?> ObtenerTiposSangreAsync(short? id = null, string? codigo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<TipoSangreDto>>>($"api/catalogo/tipos-sangre{BuildQuery(("id", id), ("codigo", codigo))}");

        // Utilidad para construir query string con parámetros opcionales
        private static string BuildQuery(params (string Key, object? Value)[] parametros)
        {
            var query = parametros
                .Where(p => p.Value != null)
                .Select(p => $"{p.Key}={p.Value}");
            var resultado = string.Join("&", query);
            return resultado.Length > 0 ? $"?{resultado}" : "";
        }
    }
}