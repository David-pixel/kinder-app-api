using KinderAdminApi.Aplicacion.Servicios;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KinderAdminApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public sealed class ColaboradorController : ControllerBase
    {
        private readonly IServicioColaboradores _servicio;

        public ColaboradorController(IServicioColaboradores servicio)
            => _servicio = servicio;

        /// <summary>
        /// Obtiene los colaboradores.
        /// </summary>
        /// <param name="activo">(Opcional) Estado del colaborador.</param>
        [HttpGet("colaboradores", Name = "ObtenerColaboradores")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de colaboradores", typeof(RespuestaGenerica<IEnumerable<ColaboradorDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontraron colaboradores")]
        public async Task<IActionResult> ObtenerColaboradores([FromQuery] bool? activo = null)
        {
            var respuesta = await _servicio.ObtenerColaboradoresAsync(activo);
            return Ok(respuesta);
        }

        /// <summary>
        /// Crea un nuevo colaborador.
        /// </summary>
        [HttpPost("crearColaborador", Name = "CrearColaborador")]
        [SwaggerResponse(StatusCodes.Status201Created, "Colaborador creado", typeof(RespuestaGenerica<ColaboradorCreadoDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitud inválida")]
        [SwaggerResponse(StatusCodes.Status409Conflict, "Identificación duplicada")]
        public async Task<ActionResult<RespuestaGenerica<ColaboradorCreadoDto>>> CrearColaborador([FromBody] CrearColaboradorDto dto)
        {
            var respuesta = await _servicio.CrearColaboradorAsync(dto);

            return StatusCode(StatusCodes.Status201Created, respuesta);
        }
    }
}