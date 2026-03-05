namespace KinderAdminApi.Compartido.Dto
{
    public sealed class DistritoDto
    {
        public int CodigoDistrito { get; set; }
        public short CodigoCanton { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}