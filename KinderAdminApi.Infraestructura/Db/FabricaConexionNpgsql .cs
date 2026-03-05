using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
namespace KinderAdminApi.Infraestructura.Db
{
    /// <summary>
    /// Implementación de una fábrica de conexiones para PostgreSQL utilizando Npgsql.
    /// </summary>
    public sealed class FabricaConexionNpgsql : IFabricaConexionDb
    {
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FabricaConexionNpgsql"/>.
        /// </summary>
        /// <param name="configuration">Provee acceso a la configuración de la aplicación.</param>
        /// <exception cref="InvalidOperationException">
        /// Se lanza cuando no se encuentra la cadena de conexión 'DefaultConnection'.
        /// </exception>
        public FabricaConexionNpgsql(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada.");
        }

        /// <summary>
        /// Crea y retorna una nueva conexión Npgsql a la base de datos PostgreSQL.
        /// </summary>
        public IDbConnection CrearConexion() => new NpgsqlConnection(_connectionString);
    }
}
