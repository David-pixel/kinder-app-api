using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using KinderAdminApi.Compartido.Dto;

namespace KinderAdminApi.BFF.Servicios
{
    public sealed class JwtServicio : IJwtServicio
    {
        private readonly IConfiguration _config;

        public JwtServicio(IConfiguration config) => _config = config;

        public RespuestaLoginDto GenerarToken(DatosLoginDto datos)
        {
            var secret = _config["Jwt:Secret"]!;
            var issuer = _config["Jwt:Issuer"]!;
            var audience = _config["Jwt:Audience"]!;
            var expiry = int.Parse(_config["Jwt:ExpiryMinutes"]!);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiraEn = DateTime.UtcNow.AddMinutes(expiry);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,        datos.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, datos.NombreUsuario),
                new Claim(JwtRegisteredClaimNames.Jti,        Guid.NewGuid().ToString())
            };

            if (datos.Roles is not null)
                foreach (var rol in datos.Roles)
                    claims.Add(new Claim(ClaimTypes.Role, rol));

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiraEn,
                signingCredentials: creds
            );

            return new RespuestaLoginDto(
                Token: new JwtSecurityTokenHandler().WriteToken(token),
                NombreUsuario: datos.NombreUsuario,
                Nombre: datos.Nombre,
                Apellido1: datos.Apellido1,
                Apellido2: datos.Apellido2,
                Correo: datos.Correo,
                Roles: datos.Roles,
                CodigosRoles: datos.CodigosRoles,
                ExpiraEn: expiraEn

            );
        }
    }
}