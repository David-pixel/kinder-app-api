namespace KinderAdminApi.Compartido.Extensiones
{
    /// <summary>
    /// Excepción personalizada que indica que el acceso no está autorizado.
    /// </summary>
    public sealed class NoAutorizadoException : Exception
    {
        /// <summary>
        /// Código de error asociado al tipo de excepción.
        /// </summary>
        public string Codigo { get; }

        /// <summary>
        /// Crea una nueva instancia de <see cref="NoAutorizadoException"/>.
        /// </summary>
        /// <param name="codigo">Código del error para identificar el tipo de fallo.</param>
        /// <param name="mensaje">Mensaje descriptivo del error.</param>
        public NoAutorizadoException(string codigo, string mensaje) : base(mensaje)
        {
            Codigo = codigo;
        }
    }
}