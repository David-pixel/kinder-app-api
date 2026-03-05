using KinderAdminApi.Aplicacion.Servicios;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KinderAdminApi.API.Controllers
{
    /// <summary>
    /// Catálogos generales del sistema KinderAPP.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CatalogoController : ControllerBase
    {
        private readonly IServicioCatalogos _servicioCatalogos;

        public CatalogoController(IServicioCatalogos servicioCatalogos)
        {
            _servicioCatalogos = servicioCatalogos;
        }

        /// <summary>
        /// Obtiene las provincias de Costa Rica.
        /// </summary>
        /// <param name="codigoProvincia">
        /// (Opcional) Código de la provincia a consultar.  
        /// Si no se envía, se devuelven todas las provincias.
        /// </param>
        /// <returns>Lista de provincias o la provincia consultada.</returns>
        [HttpGet("provincias", Name = "ObtenerProvincias")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de provincias", typeof(RespuestaGenerica<IEnumerable<ProvinciaDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontró la provincia solicitada")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<ProvinciaDto>>>> ObtenerProvincias([FromQuery] short? codigoProvincia = null)        {
            var respuesta = await _servicioCatalogos.ObtenerProvinciasAsync(codigoProvincia);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }
        /// <summary>
        /// Obtiene los cantones de Costa Rica.
        /// </summary>
        /// <param name="codigoProvincia">Código de provincia opcional para filtrar.</param>
        /// <param name="codigoCanton">Código de cantón opcional para filtrar.</param>
        [HttpGet("cantones", Name = "ObtenerCantones")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de cantones", typeof(RespuestaGenerica<IEnumerable<CantonDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron cantones")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<CantonDto>>>> ObtenerCantones(
            [FromQuery] short? codigoProvincia = null,
            [FromQuery] short? codigoCanton = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerCantonesAsync(codigoProvincia, codigoCanton);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los distritos de Costa Rica.
        /// </summary>
        /// <param name="codigoCanton">Código de cantón opcional para filtrar.</param>
        /// <param name="codigoDistrito">Código de distrito opcional para filtrar.</param>
        [HttpGet("distritos", Name = "ObtenerDistritos")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de distritos", typeof(RespuestaGenerica<IEnumerable<DistritoDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron distritos")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<DistritoDto>>>> ObtenerDistritos(
            [FromQuery] short? codigoCanton = null,
            [FromQuery] int? codigoDistrito = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerDistritosAsync(codigoCanton, codigoDistrito);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los estados de asistencia.
        /// </summary>
        /// <param name="id">(Opcional) Id del estado de asistencia.</param>
        /// <param name="codigo">(Opcional) Código del estado de asistencia.</param>
        [HttpGet("estados-asistencia", Name = "ObtenerEstadosAsistencia")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de estados de asistencia", typeof(RespuestaGenerica<IEnumerable<EstadoAsistenciaDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron estados de asistencia")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<EstadoAsistenciaDto>>>> ObtenerEstadosAsistencia(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerEstadosAsistenciaAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los estados civiles.
        /// </summary>
        /// <param name="id">(Opcional) Id del estado civil.</param>
        /// <param name="codigo">(Opcional) Código del estado civil.</param>
        [HttpGet("estados-civiles", Name = "ObtenerEstadosCiviles")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de estados civiles", typeof(RespuestaGenerica<IEnumerable<EstadoCivilDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron estados civiles")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<EstadoCivilDto>>>> ObtenerEstadosCiviles(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerEstadosCivilesAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los estados de matrícula.
        /// </summary>
        /// <param name="id">(Opcional) Id del estado de matrícula.</param>
        /// <param name="codigo">(Opcional) Código del estado de matrícula.</param>
        [HttpGet("estados-matricula", Name = "ObtenerEstadosMatricula")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de estados de matrícula", typeof(RespuestaGenerica<IEnumerable<EstadoMatriculaDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron estados de matrícula")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<EstadoMatriculaDto>>>> ObtenerEstadosMatricula(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerEstadosMatriculaAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los géneros.
        /// </summary>
        /// <param name="id">(Opcional) Id del género.</param>
        /// <param name="codigo">(Opcional) Código del género.</param>
        [HttpGet("generos", Name = "ObtenerGeneros")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de géneros", typeof(RespuestaGenerica<IEnumerable<GeneroDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron géneros")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<GeneroDto>>>> ObtenerGeneros(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerGenerosAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los grupos escolares.
        /// </summary>
        /// <param name="id">(Opcional) Id del grupo escolar.</param>
        /// <param name="codigo">(Opcional) Código del grupo escolar.</param>
        [HttpGet("grupos-escolares", Name = "ObtenerGruposEscolares")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de grupos escolares", typeof(RespuestaGenerica<IEnumerable<GrupoEscolarDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron grupos escolares")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<GrupoEscolarDto>>>> ObtenerGruposEscolares(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerGruposEscolaresAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los idiomas.
        /// </summary>
        /// <param name="id">(Opcional) Id del idioma.</param>
        /// <param name="codigo">(Opcional) Código del idioma.</param>
        [HttpGet("idiomas", Name = "ObtenerIdiomas")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de idiomas", typeof(RespuestaGenerica<IEnumerable<IdiomaDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron idiomas")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<IdiomaDto>>>> ObtenerIdiomas(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerIdiomasAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene las nacionalidades.
        /// </summary>
        /// <param name="id">(Opcional) Id de la nacionalidad.</param>
        /// <param name="codigoIso">(Opcional) Código ISO de la nacionalidad.</param>
        [HttpGet("nacionalidades", Name = "ObtenerNacionalidades")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de nacionalidades", typeof(RespuestaGenerica<IEnumerable<NacionalidadDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron nacionalidades")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<NacionalidadDto>>>> ObtenerNacionalidades(
            [FromQuery] short? id = null,
            [FromQuery] string? codigoIso = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerNacionalidadesAsync(id, codigoIso);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los niveles educativos.
        /// </summary>
        /// <param name="id">(Opcional) Id del nivel educativo.</param>
        /// <param name="codigo">(Opcional) Código del nivel educativo.</param>
        [HttpGet("niveles-educativos", Name = "ObtenerNivelesEducativos")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de niveles educativos", typeof(RespuestaGenerica<IEnumerable<NivelEducativoDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron niveles educativos")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<NivelEducativoDto>>>> ObtenerNivelesEducativos(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerNivelesEducativosAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene las ocupaciones.
        /// </summary>
        /// <param name="id">(Opcional) Id de la ocupación.</param>
        /// <param name="codigo">(Opcional) Código de la ocupación.</param>
        [HttpGet("ocupaciones", Name = "ObtenerOcupaciones")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de ocupaciones", typeof(RespuestaGenerica<IEnumerable<OcupacionDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron ocupaciones")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<OcupacionDto>>>> ObtenerOcupaciones(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerOcupacionesAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene las razones de ausencia.
        /// </summary>
        /// <param name="id">(Opcional) Id de la razón de ausencia.</param>
        /// <param name="codigo">(Opcional) Código de la razón de ausencia.</param>
        [HttpGet("razones-ausencia", Name = "ObtenerRazonesAusencia")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de razones de ausencia", typeof(RespuestaGenerica<IEnumerable<RazonAusenciaDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron razones de ausencia")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<RazonAusenciaDto>>>> ObtenerRazonesAusencia(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerRazonesAusenciaAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los roles.
        /// </summary>
        /// <param name="id">(Opcional) Id del rol.</param>
        /// <param name="codigo">(Opcional) Código del rol.</param>
        [HttpGet("roles", Name = "ObtenerRoles")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de roles", typeof(RespuestaGenerica<IEnumerable<RolDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron roles")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<RolDto>>>> ObtenerRoles(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerRolesAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los roles de aula.
        /// </summary>
        /// <param name="id">(Opcional) Id del rol de aula.</param>
        /// <param name="codigo">(Opcional) Código del rol de aula.</param>
        [HttpGet("roles-aula", Name = "ObtenerRolesAula")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de roles de aula", typeof(RespuestaGenerica<IEnumerable<RolAulaDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron roles de aula")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<RolAulaDto>>>> ObtenerRolesAula(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerRolesAulaAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los tipos de estudiante.
        /// </summary>
        /// <param name="id">(Opcional) Id del tipo de estudiante.</param>
        /// <param name="codigo">(Opcional) Código del tipo de estudiante.</param>
        [HttpGet("tipos-estudiante", Name = "ObtenerTiposEstudiante")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de tipos de estudiante", typeof(RespuestaGenerica<IEnumerable<TipoEstudianteDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron tipos de estudiante")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<TipoEstudianteDto>>>> ObtenerTiposEstudiante(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerTiposEstudianteAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los tipos de horario.
        /// </summary>
        /// <param name="id">(Opcional) Id del tipo de horario.</param>
        /// <param name="codigo">(Opcional) Código del tipo de horario.</param>
        [HttpGet("tipos-horario", Name = "ObtenerTiposHorario")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de tipos de horario", typeof(RespuestaGenerica<IEnumerable<TipoHorarioDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron tipos de horario")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<TipoHorarioDto>>>> ObtenerTiposHorario(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerTiposHorarioAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los tipos de identificación.
        /// </summary>
        /// <param name="id">(Opcional) Id del tipo de identificación.</param>
        /// <param name="codigo">(Opcional) Código del tipo de identificación.</param>
        [HttpGet("tipos-identificacion", Name = "ObtenerTiposIdentificacion")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de tipos de identificación", typeof(RespuestaGenerica<IEnumerable<TipoIdentificacionDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron tipos de identificación")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<TipoIdentificacionDto>>>> ObtenerTiposIdentificacion(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerTiposIdentificacionAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los tipos de relación.
        /// </summary>
        /// <param name="id">(Opcional) Id del tipo de relación.</param>
        /// <param name="codigo">(Opcional) Código del tipo de relación.</param>
        [HttpGet("tipos-relacion", Name = "ObtenerTiposRelacion")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de tipos de relación", typeof(RespuestaGenerica<IEnumerable<TipoRelacionDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron tipos de relación")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<TipoRelacionDto>>>> ObtenerTiposRelacion(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerTiposRelacionAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }

        /// <summary>
        /// Obtiene los tipos de sangre.
        /// </summary>
        /// <param name="id">(Opcional) Id del tipo de sangre.</param>
        /// <param name="codigo">(Opcional) Código del tipo de sangre.</param>
        [HttpGet("tipos-sangre", Name = "ObtenerTiposSangre")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de tipos de sangre", typeof(RespuestaGenerica<IEnumerable<TipoSangreDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron tipos de sangre")]
        public async Task<ActionResult<RespuestaGenerica<IEnumerable<TipoSangreDto>>>> ObtenerTiposSangre(
            [FromQuery] short? id = null,
            [FromQuery] string? codigo = null)
        {
            var respuesta = await _servicioCatalogos.ObtenerTiposSangreAsync(id, codigo);

            return respuesta.Estado switch
            {
                EstadoRespuesta.Exito => Ok(respuesta),
                EstadoRespuesta.NoEncontrado => NotFound(respuesta),
                _ => StatusCode(500, respuesta)
            };
        }
    }
}