using AutoMapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Extensiones;
using KinderAdminApi.Compartido.Repuestas;
using KinderAdminApi.Dominio.Interfaces;

namespace KinderAdminApi.Aplicacion.Servicios
{
    public sealed class ServicioUsuarios : IServicioUsuarios
    {
        private readonly IRepositorioUsuarios _repositorio;
        private readonly IMapper _mapper;

        public ServicioUsuarios(IRepositorioUsuarios repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<RespuestaGenerica<DatosLoginDto>> ObtenerDatosParaLoginAsync(string nombreUsuario, string contrasenna)
        {
            var datos = await _repositorio.ObtenerParaLoginAsync(nombreUsuario);

            if (datos is null || !datos.Activo)
                throw new NoAutorizadoException(
                    CodigosError.NoAutorizado,
                    "Credenciales inválidas.");
           var examplo =BCrypt.Net.BCrypt.HashPassword("password", 12);
            if (!BCrypt.Net.BCrypt.Verify(contrasenna, datos.ContrasennaHash.Trim()))
                throw new NoAutorizadoException(
                    CodigosError.NoAutorizado,
                    "Credenciales inválidas.");

            var dto = _mapper.Map<DatosLoginDto>(datos);
            return RespuestaGenerica<DatosLoginDto>.Exito(dto, "Credenciales verificadas correctamente.");
        }
    }
}