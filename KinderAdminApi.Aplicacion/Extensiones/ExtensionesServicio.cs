using KinderAdminApi.Aplicacion.Servicios;
using Microsoft.Extensions.DependencyInjection;

namespace KinderAdminApi.Aplicacion.Extensiones
{
    public static class ExtensionesServicio
    {
        public static IServiceCollection AgregarAplicacion(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ExtensionesServicio).Assembly));
            services.AddScoped<IServicioCatalogos, ServicioCatalogos>();
            services.AddScoped<IServicioUsuarios, ServicioUsuarios>();
            services.AddScoped<IServicioColaboradores, ServicioColaboradores>();

            return services;
        }
    }
}
