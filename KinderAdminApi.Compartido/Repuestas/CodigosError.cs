namespace KinderAdminApi.Compartido.Repuestas
{
    public static class CodigosError
    {
        // Genéricos
        public const string NoEncontrado = "ERR_NO_ENCONTRADO";
        public const string ErrorValidacion = "ERR_ERROR_VALIDACION";
        public const string NoAutorizado = "ERR_NO_AUTORIZADO";
        public const string Prohibido = "ERR_PROHIBIDO";
        public const string ErrorInterno = "ERR_ERROR_INTERNO";

        // Catálogos
        public const string CatalogoNoEncontrado = "ERR_CATALOGO_NO_ENCONTRADO";

        // Estudiantes
        public const string EstudianteNoEncontrado = "ERR_ESTUDIANTE_NO_ENCONTRADO";
        public const string EstudianteDuplicado = "ERR_ESTUDIANTE_DUPLICADO";
        public const string ErrorCreacionEstudiante = "ERR_ERROR_CREACION_ESTUDIANTE";

        // Matrículas
        public const string MatriculaNoEncontrada = "ERR_MATRICULA_NO_ENCONTRADA";
        public const string MatriculaDuplicada = "ERR_MATRICULA_DUPLICADA";
    }
}
