namespace KinderAdminApi.Compartido.Repuestas
{
    /// <summary>
    /// Define los estados posibles de una respuesta generada por la API.
    /// </summary>
    public enum EstadoRespuesta
    {
        /// <summary>
        /// La operación finalizó correctamente.
        /// </summary>
        Exito = 0,

        /// <summary>
        /// La operación falló por un error genérico.
        /// </summary>
        Fallido = 1,

        /// <summary>
        /// La solicitud no cumple con las validaciones requeridas.
        /// </summary>
        ErrorValidacion = 2,

        /// <summary>
        /// El recurso solicitado no fue encontrado.
        /// </summary>
        NoEncontrado = 3,

        /// <summary>
        /// El usuario no está autorizado para realizar esta operación.
        /// </summary>
        NoAutorizado = 4
    }
}
