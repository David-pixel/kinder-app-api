namespace KinderAdminApi.Compartido.Repuestas
{
    /// <summary>
    /// Representa un error retornado por la API.
    /// </summary>
    public sealed class DetalleError
    {
        /// <summary>
        /// Código único del error. Suele provenir de <see cref="CodigosError"/>.
        /// </summary>
        public string? Codigo { get; init; }

        /// <summary>
        /// Mensaje principal del error brindado al cliente.
        /// </summary>
        public string Mensaje { get; init; } = string.Empty;

        /// <summary>
        /// Lista de errores adicionales, comúnmente asociada a validaciones.
        /// Key: nombre del campo, Value: lista de errores.
        /// </summary>
        public IDictionary<string, string[]>? Detalles { get; init; }

        /// <summary>
        /// Constructor vacío requerido para serialización.
        /// </summary>
        public DetalleError() { }

        /// <summary>
        /// Crea una instancia de error con información detallada.
        /// </summary>
        /// <param name="codigo">Código único del error.</param>
        /// <param name="mensaje">Mensaje principal del error.</param>
        /// <param name="detalles">Detalles opcionales del error.</param>
        public DetalleError(string codigo, string mensaje, IDictionary<string, string[]>? detalles = null)
        {
            Codigo = codigo;
            Mensaje = mensaje;
            Detalles = detalles;
        }
    }
}
