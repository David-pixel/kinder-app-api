namespace KinderAdminApi.Compartido.Dto
{
    /// <summary>
    /// Respuesta del login: token JWT + datos del usuario autenticado.
    /// </summary>
    public sealed record RespuestaLoginDto(
        string Token,
        string NombreUsuario,
        string? Nombre,
        string? Apellido1,
        string? Apellido2,
        string? Correo,
        string[]? Roles,
        string[]? CodigosRoles,
        DateTime ExpiraEn
    );
}