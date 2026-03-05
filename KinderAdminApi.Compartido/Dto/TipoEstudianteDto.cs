namespace KinderAdminApi.Compartido.Dto
{
    public sealed class TipoEstudianteDto
    {
        public short Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTimeOffset CreadoEn { get; set; }
    }
}