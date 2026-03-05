namespace KinderAdminApi.Compartido.Repuestas
{
    /// <summary>
    /// Representa una respuesta genérica que incluye datos asociados al resultado.
    /// </summary>
    /// <typeparam name="T">Tipo de dato retornado por la operación.</typeparam>
    public sealed class RespuestaGenerica<T> : Respuesta
    {
        /// <summary>
        /// Datos retornados por la operación. Puede ser nulo en caso de error.
        /// </summary>
        public T? Datos { get; set; }

        /// <summary>
        /// Constructor vacío requerido para serialización.
        /// </summary>
        public RespuestaGenerica() { }

        /// <summary>
        /// Crea una respuesta de éxito con datos.
        /// </summary>
        /// <param name="datos">Datos retornados.</param>
        /// <param name="mensaje">Mensaje opcional.</param>
        /// <param name="correlationId">Id de correlación opcional.</param>
        public RespuestaGenerica(T datos, string? mensaje = null, string? correlationId = null)
        {
            Datos = datos;
            Estado = EstadoRespuesta.Exito;
            Mensaje = mensaje;
            CorrelationId = correlationId ?? Guid.NewGuid().ToString("D");
            Timestamp = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Fábrica para crear una respuesta de éxito.
        /// </summary>
        public static RespuestaGenerica<T> Exito(T datos, string? mensaje = null, string? correlationId = null)
        {
            return new RespuestaGenerica<T>(datos, mensaje, correlationId);
        }

        /// <summary>
        /// Fábrica para crear una respuesta de error.
        /// </summary>
        public static RespuestaGenerica<T> Fallo(string mensaje, DetalleError? error = null, EstadoRespuesta estado = EstadoRespuesta.Fallido, string? correlationId = null)
        {
            return new RespuestaGenerica<T>
            {
                Datos = default,
                Estado = estado,
                Mensaje = mensaje,
                Error = error,
                CorrelationId = correlationId ?? Guid.NewGuid().ToString("D"),
                Timestamp = DateTimeOffset.UtcNow,
            };
        }

        /// <summary>
        /// Crea una respuesta a partir de una excepción.
        /// </summary>
        /// <param name="ex">Excepción capturada.</param>
        /// <param name="incluirStack">Indica si se debe incluir el stack trace.</param>
        /// <param name="correlationId">Id de correlación opcional.</param>
        public static RespuestaGenerica<T> DesdeExcepcion(
            Exception ex,
            bool incluirStack = false,
            string? correlationId = null)
        {
            var detalle = new DetalleError(
                ex.GetType().Name,
                incluirStack ? ex.ToString() ?? ex.Message : ex.Message);

            return Fallo(
                "Ocurrió un error inesperado.",
                detalle,
                EstadoRespuesta.Fallido,
                correlationId);
        }
    }
}
