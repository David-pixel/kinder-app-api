using System.Data;

namespace KinderAdminApi.Infraestructura.Db
{
    /// <summary>
    /// Define la fábrica responsable de crear conexiones a la base de datos.
    /// </summary>
    public interface IFabricaConexionDb
    {
        /// <summary>
        /// Crea y retorna una nueva conexión a la base de datos.
        /// </summary>
        /// <returns>Una instancia de <see cref="IDbConnection"/> lista para usar.</returns>
        IDbConnection CrearConexion();
    }
}
