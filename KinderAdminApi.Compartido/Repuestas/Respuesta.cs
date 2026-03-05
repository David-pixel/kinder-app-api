namespace KinderAdminApi.Compartido.Repuestas
{
    /// <summary>
    /// Representa la estructura estándar de respuesta utilizada por la API.
    /// </summary>
    public class Respuesta
    {
        /// <summary>
        /// Estado de la respuesta (Éxito o Error).
        /// </summary>
        public EstadoRespuesta Estado { get; set; } = EstadoRespuesta.Exito;

        /// <summary>
        /// Mensaje descriptivo de la operación.
        /// </summary>
        public string? Mensaje { get; set; }

        /// <summary>
        /// Información detallada del error, si aplica.
        /// </summary>
        public DetalleError? Error { get; set; }

        /// <summary>
        /// Id único que permite rastrear la operación a través del sistema.
        /// </summary>
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString("D");

        /// <summary>
        /// Marca de tiempo (UTC) en la que se generó la respuesta.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// Indica si la operación finalizó correctamente.
        /// </summary>
        public bool EsExito => Estado == EstadoRespuesta.Exito;

        /// <summary>
        /// Constructor vacío requerido para serialización.
        /// </summary>
        public Respuesta() { }

        /// <summary>
        /// Crea una respuesta con estado de error.
        /// </summary>
        /// <param name="mensaje">Mensaje principal del error.</param>
        /// <param name="error">Detalle opcional del error.</param>
        /// <param name="estado">Estado de la respuesta (por defecto: Fallido).</param>
        /// <param name="correlationId">Identificador de correlación opcional.</param>
        /// <returns>Una instancia de <see cref="Respuesta"/> representando un error.</returns>
        public static Respuesta CrearError(string mensaje,DetalleError? error = null,EstadoRespuesta estado = EstadoRespuesta.Fallido,string? correlationId = null)
        {
            return new Respuesta
            {
                Estado = estado,
                Mensaje = mensaje,
                Error = error,
                CorrelationId = correlationId ?? Guid.NewGuid().ToString("D"),
                Timestamp = DateTimeOffset.UtcNow
            };
        }
    }
}
