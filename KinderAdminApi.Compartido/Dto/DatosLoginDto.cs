namespace KinderAdminApi.Compartido.Dto
{
    /// <summary>
    /// Datos retornados por la función fn_login: información del usuario + hash de contraseña + roles.
    /// Usado por BFF/API para validar credenciales y generar JWT.
    /// </summary>
    public sealed record DatosLoginDto(
        long IdUsuario,
        string NombreUsuario,
        string ContrasennaHash,
        bool Activo,
        bool CorreoVerificado,
        string? Nombre,
        string? Apellido1,
        string? Apellido2,
        string? Correo,
        string[]? Roles,
        string[]? CodigosRoles
    );
}
