namespace KinderAdminApi.Compartido.Extensiones
{
    /// <summary>
    /// Excepción personalizada que indica que un recurso no fue encontrado.
    /// </summary>
    public sealed class NoEncontradoException : Exception
    {
        /// <summary>
        /// Código de error asociado al tipo de excepción.
        /// </summary>
        public string Codigo { get; }

        /// <summary>
        /// Crea una nueva instancia de <see cref="NoEncontradoException"/>.
        /// </summary>
        /// <param name="codigo">Código del error para identificar el tipo de fallo.</param>
        /// <param name="mensaje">Mensaje descriptivo del error.</param>
        public NoEncontradoException(string codigo, string mensaje): base(mensaje)
        {
            Codigo = codigo;
        }
    }
}
