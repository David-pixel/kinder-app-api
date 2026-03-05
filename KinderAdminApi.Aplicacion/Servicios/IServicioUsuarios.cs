using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;

namespace KinderAdminApi.Aplicacion.Servicios
{
    public interface IServicioUsuarios
    {
        Task<RespuestaGenerica<DatosLoginDto>> ObtenerDatosParaLoginAsync(string nombreUsuario, string contrasenna);
    }
}