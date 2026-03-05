namespace KinderAdminApi.Compartido.Dto
{
    public sealed class EstadoAsistenciaDto
    {
        public short Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int OrdenVisualizacion { get; set; }
        public bool Activo { get; set; }
        public DateTimeOffset CreadoEn { get; set; }
    }
}