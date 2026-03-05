namespace KinderAdminApi.Dominio.Entidades
{
    public class CrearColaborador
    {
        public short IdTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public short IdRol { get; set; }
        public DateTime FechaContratacion { get; set; }
        public string? Apellido2 { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public short? IdGenero { get; set; }
        public short? IdNacionalidad { get; set; }
        public short? IdEstadoCivil { get; set; }
        public short? IdNivelEducativo { get; set; }
        public short? IdOcupacion { get; set; }
        public short? IdTipoSangre { get; set; }
        public string? Correo { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? TelefonoFijo { get; set; }
        public short? CodigoProvincia { get; set; }
        public short? CodigoCanton { get; set; }
        public int? CodigoDistrito { get; set; }
        public string? DetalleDireccion { get; set; }
    }

}
