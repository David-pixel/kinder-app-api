using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;

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
            => ObtenerAsync<RespuestaGenerica<IEnumerable<ColaboradorDto>>>($"api/colaboradorControl/colaboradores{(activo.HasValue ? $"?activo={activo.Value.ToString().ToLower()}" : "")}");
    }
}