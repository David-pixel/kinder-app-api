namespace KinderAdminApi.Dominio.Entidades
{
    public sealed class Distrito
    {
        public int CodigoDistrito { get; set; }
        public short CodigoCanton { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}