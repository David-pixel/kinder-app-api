namespace KinderAdminApi.Dominio.Entidades
{
    public sealed class Idioma
    {
        public short Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTimeOffset CreadoEn { get; set; }
    }
}