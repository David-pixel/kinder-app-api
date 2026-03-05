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
    public sealed class AuthController : ControllerBase
    {
        private readonly IServicioUsuarios _servicio;

        public AuthController(IServicioUsuarios servicio) => _servicio = servicio;

        /// <summary>
        /// Valida credenciales y retorna los datos del usuario para que el BFF genere el JWT.
        /// </summary>
        [HttpPost("login", Name = "Login")]
        [SwaggerResponse(StatusCodes.Status200OK, "Credenciales válidas", typeof(RespuestaGenerica<DatosLoginDto>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Credenciales inválidas")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var respuesta = await _servicio.ObtenerDatosParaLoginAsync(
                request.NombreUsuario,
                request.Contrasenna);

            return Ok(respuesta);
        }
    }
}