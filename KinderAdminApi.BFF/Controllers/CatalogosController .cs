using KinderAPP.BFF.Clients;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KinderAPP.BFF.Controllers
{
    /// <summary>
    /// Catálogos generales del sistema KinderAPP.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public sealed class CatalogosController : ControllerBase
    {
        private readonly ClienteCatalogos _cliente;

        public CatalogosController(ClienteCatalogos cliente) => _cliente = cliente;

        /// <summary>Obtiene los tipos de identificación</summary>
        [HttpGet("tipos-identificacion", Name = "BFF_ObtenerTiposIdentificacion")]
        [SwaggerResponse(200, "Lista de tipos de identificación", typeof(RespuestaGenerica<IEnumerable<TipoIdentificacionDto>>))]
        public async Task<IActionResult> ObtenerTiposIdentificacion()
        {
            var resultado = await _cliente.ObtenerTiposIdentificacionAsync();
            return Ok(resultado);
        }

        /// <summary>Obtiene los géneros</summary>
        [HttpGet("generos", Name = "BFF_ObtenerGeneros")]
        [SwaggerResponse(200, "Lista de géneros", typeof(RespuestaGenerica<IEnumerable<GeneroDto>>))]
        public async Task<IActionResult> ObtenerGeneros()
        {
            var resultado = await _cliente.ObtenerGenerosAsync();
            return Ok(resultado);
        }

        /// <summary>Obtiene los estados de matrícula</summary>
        [HttpGet("estados-matricula", Name = "BFF_ObtenerEstadosMatricula")]
        [SwaggerResponse(200, "Lista de estados de matrícula", typeof(RespuestaGenerica<IEnumerable<EstadoMatriculaDto>>))]
        public async Task<IActionResult> ObtenerEstadosMatricula()
        {
            var resultado = await _cliente.ObtenerEstadosMatriculaAsync();
            return Ok(resultado);
        }

        /// <summary>Obtiene las razones de ausencia</summary>
        [HttpGet("razones-ausencia", Name = "BFF_ObtenerRazonesAusencia")]
        [SwaggerResponse(200, "Lista de razones de ausencia", typeof(RespuestaGenerica<IEnumerable<RazonAusenciaDto>>))]
        public async Task<IActionResult> ObtenerRazonesAusencia()
        {
            var resultado = await _cliente.ObtenerRazonesAusenciaAsync();
            return Ok(resultado);
        }

        /// <summary>Obtiene los estados de asistencia</summary>
        [HttpGet("estados-asistencia", Name = "BFF_ObtenerEstadosAsistencia")]
        [SwaggerResponse(200, "Lista de estados de asistencia", typeof(RespuestaGenerica<IEnumerable<EstadoAsistenciaDto>>))]
        public async Task<IActionResult> ObtenerEstadosAsistencia()
        {
            var resultado = await _cliente.ObtenerEstadosAsistenciaAsync();
            return Ok(resultado);
        }

        /// <summary>Obtiene las provincias</summary>
        [HttpGet("provincias", Name = "BFF_ObtenerProvincias")]
        [SwaggerResponse(200, "Lista de provincias", typeof(RespuestaGenerica<IEnumerable<ProvinciaDto>>))]
        public async Task<IActionResult> ObtenerProvincias()
        {
            var resultado = await _cliente.ObtenerProvinciasAsync();
            return Ok(resultado);
        }

        /// <summary>Obtiene los cantones, opcionalmente filtrados por provincia</summary>
        [HttpGet("cantones", Name = "BFF_ObtenerCantones")]
        [SwaggerResponse(200, "Lista de cantones", typeof(RespuestaGenerica<IEnumerable<CantonDto>>))]
        public async Task<IActionResult> ObtenerCantones([FromQuery] short? codigoProvincia = null)
        {
            var resultado = await _cliente.ObtenerCantonesAsync(codigoProvincia);
            return Ok(resultado);
        }

        /// <summary>Obtiene los distritos, opcionalmente filtrados por cantón</summary>
        [HttpGet("distritos", Name = "BFF_ObtenerDistritos")]
        [SwaggerResponse(200, "Lista de distritos", typeof(RespuestaGenerica<IEnumerable<DistritoDto>>))]
        public async Task<IActionResult> ObtenerDistritos([FromQuery] short? codigoCanton = null)
        {
            var resultado = await _cliente.ObtenerDistritosAsync(codigoCanton);
            return Ok(resultado);
        }

        /// <summary>Obtiene los niveles educativos</summary>
        [HttpGet("niveles-educativos", Name = "BFF_ObtenerNivelesEducativos")]
        [SwaggerResponse(200, "Lista de niveles educativos", typeof(RespuestaGenerica<IEnumerable<NivelEducativoDto>>))]
        public async Task<IActionResult> ObtenerNivelesEducativos([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerNivelesEducativosAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene los idiomas</summary>
        [HttpGet("idiomas", Name = "BFF_ObtenerIdiomas")]
        [SwaggerResponse(200, "Lista de idiomas", typeof(RespuestaGenerica<IEnumerable<IdiomaDto>>))]
        public async Task<IActionResult> ObtenerIdiomas([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerIdiomasAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene los estados civiles</summary>
        [HttpGet("estados-civiles", Name = "BFF_ObtenerEstadosCiviles")]
        [SwaggerResponse(200, "Lista de estados civiles", typeof(RespuestaGenerica<IEnumerable<EstadoCivilDto>>))]
        public async Task<IActionResult> ObtenerEstadosCiviles([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerEstadosCivilesAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene las nacionalidades</summary>
        [HttpGet("nacionalidades", Name = "BFF_ObtenerNacionalidades")]
        [SwaggerResponse(200, "Lista de nacionalidades", typeof(RespuestaGenerica<IEnumerable<NacionalidadDto>>))]
        public async Task<IActionResult> ObtenerNacionalidades([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerNacionalidadesAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene las ocupaciones</summary>
        [HttpGet("ocupaciones", Name = "BFF_ObtenerOcupaciones")]
        [SwaggerResponse(200, "Lista de ocupaciones", typeof(RespuestaGenerica<IEnumerable<OcupacionDto>>))]
        public async Task<IActionResult> ObtenerOcupaciones([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerOcupacionesAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene los tipos de relación</summary>
        [HttpGet("tipos-relacion", Name = "BFF_ObtenerTiposRelacion")]
        [SwaggerResponse(200, "Lista de tipos de relación", typeof(RespuestaGenerica<IEnumerable<TipoRelacionDto>>))]
        public async Task<IActionResult> ObtenerTiposRelacion([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerTiposRelacionAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene los roles</summary>
        [HttpGet("roles", Name = "BFF_ObtenerRoles")]
        [SwaggerResponse(200, "Lista de roles", typeof(RespuestaGenerica<IEnumerable<RolDto>>))]
        public async Task<IActionResult> ObtenerRoles([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerRolesAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene los tipos de horario</summary>
        [HttpGet("tipos-horario", Name = "BFF_ObtenerTiposHorario")]
        [SwaggerResponse(200, "Lista de tipos de horario", typeof(RespuestaGenerica<IEnumerable<TipoHorarioDto>>))]
        public async Task<IActionResult> ObtenerTiposHorario([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerTiposHorarioAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene los grupos escolares</summary>
        [HttpGet("grupos-escolares", Name = "BFF_ObtenerGruposEscolares")]
        [SwaggerResponse(200, "Lista de grupos escolares", typeof(RespuestaGenerica<IEnumerable<GrupoEscolarDto>>))]
        public async Task<IActionResult> ObtenerGruposEscolares([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerGruposEscolaresAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene los tipos de estudiante</summary>
        [HttpGet("tipos-estudiante", Name = "BFF_ObtenerTiposEstudiante")]
        [SwaggerResponse(200, "Lista de tipos de estudiante", typeof(RespuestaGenerica<IEnumerable<TipoEstudianteDto>>))]
        public async Task<IActionResult> ObtenerTiposEstudiante([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerTiposEstudianteAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene los roles de aula</summary>
        [HttpGet("roles-aula", Name = "BFF_ObtenerRolesAula")]
        [SwaggerResponse(200, "Lista de roles de aula", typeof(RespuestaGenerica<IEnumerable<RolAulaDto>>))]
        public async Task<IActionResult> ObtenerRolesAula([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerRolesAulaAsync(id);
            return Ok(resultado);
        }

        /// <summary>Obtiene los tipos de sangre</summary>
        [HttpGet("tipos-sangre", Name = "BFF_ObtenerTiposSangre")]
        [SwaggerResponse(200, "Lista de tipos de sangre", typeof(RespuestaGenerica<IEnumerable<TipoSangreDto>>))]
        public async Task<IActionResult> ObtenerTiposSangre([FromQuery] short? id = null)
        {
            var resultado = await _cliente.ObtenerTiposSangreAsync(id);
            return Ok(resultado);
        }
    }
}