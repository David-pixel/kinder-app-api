using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;
using System.Net.Http.Json;

namespace KinderAPP.BFF.Clients
{
    public sealed class ClienteColaboradores
    {
        private readonly HttpClient _http;

        public ClienteColaboradores(HttpClient http) => _http = http;

        private async Task<T?> ObtenerAsync<T>(string url)
        {
            var respuesta = await _http.GetAsync(url);
            return await respuesta.Content.ReadFromJsonAsync<T>();
        }

        public Task<RespuestaGenerica<IEnumerable<ColaboradorDto>>?> ObtenerColaboradoresAsync(bool? activo = null)
            => ObtenerAsync<RespuestaGenerica<IEnumerable<ColaboradorDto>>>(
                $"api/colaborador/colaboradores{BuildQuery(("activo", activo))}");
        public async Task<RespuestaGenerica<ColaboradorDto>?> CrearColaboradorAsync(CrearColaboradorDto dto)
        {
            var respuesta = await _http.PostAsJsonAsync("api/colaborador/crearColaborador", dto);

            return await respuesta.Content.ReadFromJsonAsync<RespuestaGenerica<ColaboradorDto>>();
        }

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