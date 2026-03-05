using Dapper;
using KinderAdminApi.Dominio.Entidades;
using KinderAdminApi.Dominio.Interfaces;
using KinderAdminApi.Infraestructura.Db;

namespace KinderAdminApi.Infraestructura.Repositorios
{
    public sealed class RepositorioUsuariosDapper : IRepositorioUsuarios
    {
        private readonly IFabricaConexionDb _fabrica;

        public RepositorioUsuariosDapper(IFabricaConexionDb fabrica) => _fabrica = fabrica;

        public async Task<DatosLogin?> ObtenerParaLoginAsync(string nombreUsuario)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = "SELECT * FROM fn_login(@p_nombre_usuario);";

            var parametros = new { p_nombre_usuario = nombreUsuario };

            // Si la función puede devolver múltiples filas (no debería), usamos QuerySingleOrDefault.
            var resultado = await conexion.QuerySingleOrDefaultAsync<DatosLogin>(sql, parametros);
            return resultado;
        }
    }
}