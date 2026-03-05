using System.Collections.Generic;
using System.Threading.Tasks;
using KinderAdminApi.Dominio.Entidades;

namespace KinderAdminApi.Dominio.Interfaces
{
    public interface IRepositorioColaboradores
    {
        /// <summary>
        /// Obtiene colaboradores según su estado activo (NULL = todos, TRUE = activos, FALSE = inactivos).
        /// </summary>
        Task<IEnumerable<Colaborador>> ObtenerColaboradoresAsync(bool? activo = null);
        /// <summary>
        /// Crea un colaborador.
        /// </summary>
        Task<ColaboradorCreado> CrearColaboradorAsync(CrearColaborador dto);
    }
}