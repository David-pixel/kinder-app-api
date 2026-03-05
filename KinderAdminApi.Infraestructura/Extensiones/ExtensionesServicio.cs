using KinderAdminApi.Dominio.Interfaces;
using KinderAdminApi.Infraestructura.Db;
using KinderAdminApi.Infraestructura.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace KinderAdminApi.Infraestructura.Extensiones
{
    public static class ExtensionesServicio
    {
        public static IServiceCollection AgregarInfraestructura(this IServiceCollection servicios)
        {

            // Conexión a PostgreSQL
            servicios.AddSingleton<IFabricaConexionDb, FabricaConexionNpgsql>();

            // Repositorios Dapper
            servicios.AddScoped<IRepositorioCatalogos, RepositorioCatalogosDapper>();
            servicios.AddScoped<IRepositorioUsuarios, RepositorioUsuariosDapper>();
            servicios.AddScoped<IRepositorioColaboradores, RepositorioColaboradoresDapper>();


            return servicios;
        }
    }
}
