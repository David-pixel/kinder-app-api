namespace KinderAdminApi.Dominio.Entidades
{
    public sealed class DatosLogin
    {
        public long IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string ContrasennaHash { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public bool CorreoVerificado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? Correo { get; set; }
        public string[]? Roles { get; set; }
        public string[]? CodigosRoles { get; set; }
    }
}
