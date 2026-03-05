using System.Collections.Generic;
using System.Threading.Tasks;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Compartido.Repuestas;

namespace KinderAdminApi.Aplicacion.Servicios
{
    public interface IServicioColaboradores
    {
        Task<RespuestaGenerica<IEnumerable<ColaboradorDto>>> ObtenerColaboradoresAsync(bool? activo = null);
        Task<RespuestaGenerica<ColaboradorCreadoDto>> CrearColaboradorAsync(CrearColaboradorDto dto);
    }
}