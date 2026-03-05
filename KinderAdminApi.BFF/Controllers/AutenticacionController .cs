using KinderAPP.BFF.Clients;
using KinderAdminApi.BFF.Servicios;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KinderAPP.BFF.Controllers
{
    /// <summary>
    /// Autenticación del sistema KinderAPP.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public sealed class AutenticacionController : ControllerBase
    {
        private readonly ClienteAutenticacion _cliente;
        private readonly IJwtServicio _jwt;

        public AutenticacionController(ClienteAutenticacion cliente, IJwtServicio jwt)
        {
            _cliente = cliente;
            _jwt = jwt;
        }

        /// <summary>Inicia sesión con nombre de usuario y contraseña</summary>
        [HttpPost("login", Name = "BFF_Login")]
        [SwaggerResponse(200, "Login exitoso", typeof(RespuestaGenerica<RespuestaLoginDto>))]
        [SwaggerResponse(401, "Credenciales inválidas", typeof(RespuestaGenerica<object>))]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var resultado = await _cliente.LoginAsync(request);

            if (resultado is null || !resultado.EsExito || resultado.Datos is null)
                return StatusCode(StatusCodes.Status401Unauthorized, resultado);

            var respuesta = _jwt.GenerarToken(resultado.Datos);

            return Ok(RespuestaGenerica<RespuestaLoginDto>.Exito(respuesta, "Login exitoso."));
        }
    }
}