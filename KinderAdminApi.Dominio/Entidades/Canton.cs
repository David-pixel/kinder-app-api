namespace KinderAdminApi.Dominio.Entidades
{
    public sealed class Canton
    {
        public short CodigoCanton { get; set; }
        public short CodigoProvincia { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
