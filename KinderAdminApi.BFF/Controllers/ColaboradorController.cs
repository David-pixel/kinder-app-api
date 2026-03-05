using KinderAPP.BFF.Clients;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KinderAdminApi.BFF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public sealed class ColaboradoresController : ControllerBase
    {
        private readonly ClienteColaboradores _cliente;

        public ColaboradoresController(ClienteColaboradores cliente) => _cliente = cliente;


        /// <summary>Obtiene los colaboradores, opcionalmente filtrados por estado</summary>
        [HttpGet("colaboradores", Name = "BFF_ObtenerColaboradores")]
        [SwaggerResponse(200, "Lista de colaboradores", typeof(RespuestaGenerica<IEnumerable<ColaboradorDto>>))]
        public async Task<IActionResult> ObtenerColaboradores([FromQuery] bool? activo = null)
        {
            var resultado = await _cliente.ObtenerColaboradoresAsync(activo);
            return Ok(resultado);
        }
        /// <summary>Crea un colaborador</summary>
        [HttpPost("crearColaborador")]
        public async Task<IActionResult> CrearColaborador([FromBody] CrearColaboradorDto dto)
        {
            var respuesta = await _cliente.CrearColaboradorAsync(dto);
            return Ok(respuesta);
        }
    }
}