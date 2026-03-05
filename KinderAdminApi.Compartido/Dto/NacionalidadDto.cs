namespace KinderAdminApi.Compartido.Dto
{
    public sealed class NacionalidadDto
    {
        public short Id { get; set; }
        public string CodigoIso { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTimeOffset CreadoEn { get; set; }
    }
}