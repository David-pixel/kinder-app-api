using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;
using KinderAPP.BFF.Clients;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Xunit;


namespace KinderAdminApi.Pruebas
{
    internal sealed class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage _response;
        public FakeHttpMessageHandler(HttpResponseMessage response) => _response = response;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(_response);
    }

    public class ClienteCatalogosTests
    {
        [Fact]
        public async Task ObtenerProvinciasAsync_DebeDevolverListaDeProvincias()
        {
            // Arrange: payload esperado
            var payload = new RespuestaGenerica<IEnumerable<ProvinciaDto>>
            {
                Datos = new List<ProvinciaDto>
                {
                    new ProvinciaDto { CodigoProvincia = 1, Nombre = "San José", Activo = true }
                }
            };

            var json = JsonSerializer.Serialize(payload);
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };
            httpResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var handler = new FakeHttpMessageHandler(httpResponse);
            var httpClient = new HttpClient(handler) { BaseAddress = new System.Uri("https://example.test/") };
            var cliente = new ClienteCatalogos(httpClient);

            // Act
            var resultado = await cliente.ObtenerProvinciasAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.NotNull(resultado!.Datos);
            var primera = resultado.Datos.First();
            Assert.Equal(1, primera.CodigoProvincia);
            Assert.Equal("San José", primera.Nombre);
        }
    }
}