using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;
using Microsoft.AspNetCore.Identity.Data;

namespace KinderAPP.BFF.Clients
{
    public sealed class ClienteAutenticacion
    {
        private readonly HttpClient _http;

        public ClienteAutenticacion(HttpClient http) => _http = http;

        public async Task<RespuestaGenerica<DatosLoginDto>?> LoginAsync(LoginRequestDto request)
        {
            var respuesta = await _http.PostAsJsonAsync("api/auth/login", request);
            return await respuesta.Content.ReadFromJsonAsync<RespuestaGenerica<DatosLoginDto>>();
        }
    }
}