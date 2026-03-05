using Npgsql;

namespace KinderAdminApi.Infraestructura.Ayudas
{
    /// <summary>
    /// Proporciona métodos para construir cadenas de conexión a PostgreSQL usando Npgsql.
    /// </summary>
    public static class FabricaConexionNpgsql
    {
        /// <summary>
        /// Construye una cadena de conexión a PostgreSQL a partir de los parámetros proporcionados.
        /// </summary>
        /// <param name="host">Servidor o dirección del host donde se encuentra PostgreSQL.</param>
        /// <param name="port">Puerto de conexión.</param>
        /// <param name="database">Nombre de la base de datos.</param>
        /// <param name="user">Usuario de acceso a la base de datos.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <param name="useSsl">Indica si debe utilizarse SSL para la conexión.</param>
        /// <returns>Una cadena de conexión válida para Npgsql.</returns>
        public static string Construir(
            string host,
            int port,
            string database,
            string user,
            string password,
            bool useSsl = true)
        {
            var csb = new NpgsqlConnectionStringBuilder
            {
                Host = host,
                Port = port,
                Database = database,
                Username = user,
                Password = password,
                Pooling = true,
                SslMode = useSsl ? SslMode.Require : SslMode.Disable,
                TrustServerCertificate = true
            };

            return csb.ConnectionString;
        }
    }
}
