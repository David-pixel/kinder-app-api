using KinderAdminApi.Compartido.Dto;

namespace KinderAdminApi.BFF.Servicios
{
    public interface IJwtServicio
    {
        RespuestaLoginDto GenerarToken(DatosLoginDto datos);
    }
}