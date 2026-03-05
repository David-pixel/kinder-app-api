

using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Dominio.Interfaces
{
    public interface IRepositorioUsuarios
    {
        /// <summary>
        /// Obtiene los datos necesarios para autenticar a un usuario (incluye hash de contraseña y roles).
        /// Devuelve null si no existe.
        /// </summary>
        Task<DatosLogin?> ObtenerParaLoginAsync(string nombreUsuario);
    }
}