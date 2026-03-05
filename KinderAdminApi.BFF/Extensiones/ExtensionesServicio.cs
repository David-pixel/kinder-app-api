using KinderAdminApi.BFF.Servicios;
using KinderAPP.BFF.Clients;

namespace KinderAdminApi.BFF.Extensiones
{
    public static class ExtensionesServicio
    {
        public static IServiceCollection AgregarServiciosBff(this IServiceCollection services, IConfiguration config)
        {
            var urlBase = config["KinderApi:BaseUrl"]!;
            var apiKey = config["KinderApi:ApiKey"]!;

            services.AddHttpClient<ClienteCatalogos>(client =>
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            });
            services.AddHttpClient<ClienteAutenticacion>(client =>
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            });
            services.AddHttpClient<ClienteColaboradores>(client =>
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            });
            services.AddScoped<IJwtServicio, JwtServicio>();

            return services;
        }
    }
}
