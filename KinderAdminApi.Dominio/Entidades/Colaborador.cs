using System;

namespace KinderAdminApi.Dominio.Entidades
{
    public sealed class Colaborador
    {
        public long IdColaborador { get; set; }
        public string? CodigoColaborador { get; set; }
        public long IdPersona { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? Correo { get; set; }
        public string? TelefonoCelular { get; set; }
        public short IdRol { get; set; }
        public string? RolCodigo { get; set; }
        public string? RolNombre { get; set; }
        public short IdEstado { get; set; }
        public string? EstadoCodigo { get; set; }
        public string? EstadoNombre { get; set; }
        public DateTime FechaContratacion { get; set; }
        public DateTime? FechaSalida { get; set; }
        public bool Activo { get; set; }
        public bool TieneUsuario { get; set; }
        public string[]? Grupos { get; set; }
    }
}