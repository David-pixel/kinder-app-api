namespace KinderAdminApi.Compartido.Dto
{
    public sealed class ProvinciaDto
    {
        public short CodigoProvincia { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
