using Dapper;
using KinderAdminApi.Compartido.Dto;
using KinderAdminApi.Dominio.Entidades;
using KinderAdminApi.Dominio.Interfaces;
using KinderAdminApi.Infraestructura.Db;
using System.Data;

namespace KinderAdminApi.Infraestructura.Repositorios
{
    public sealed class RepositorioColaboradoresDapper : IRepositorioColaboradores
    {
        private readonly IFabricaConexionDb _fabrica;

        public RepositorioColaboradoresDapper(IFabricaConexionDb fabrica)
        {
            _fabrica = fabrica;
        }

        public async Task<IEnumerable<Colaborador>> ObtenerColaboradoresAsync(bool? activo = null)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"SELECT id_colaborador,
                                        codigo_colaborador,
                                        id_persona,
                                        nombre_completo,
                                        nombre,
                                        apellido1,
                                        apellido2,
                                        correo,
                                        telefono_celular,
                                        id_rol,
                                        rol_codigo,
                                        rol_nombre,
                                        id_estado,
                                        estado_codigo,
                                        estado_nombre,
                                        fecha_contratacion,
                                        fecha_salida,
                                        activo,
                                        tiene_usuario,
                                        grupos
                                   FROM fn_obtener_colaboradores(@p_activo);";

            return await conexion.QueryAsync<Colaborador>(sql, new
            {
                p_activo = activo
            });
        }

        public async Task<ColaboradorCreado> CrearColaboradorAsync(CrearColaborador dto)
        {
            using var conexion = _fabrica.CrearConexion();

            const string sql = @"
        SELECT id_colaborador,
               codigo_colaborador
        FROM fn_crear_colaborador(
            @p_id_tipo_identificacion,
            @p_numero_identificacion,
            @p_nombre,
            @p_apellido1,
            @p_id_rol,
            @p_fecha_contratacion,
            @p_apellido2,
            @p_fecha_nacimiento,
            @p_id_genero,
            @p_id_nacionalidad,
            @p_id_estado_civil,
            @p_id_nivel_educativo,
            @p_id_ocupacion,
            @p_id_tipo_sangre,
            @p_correo,
            @p_telefono_celular,
            @p_telefono_fijo,
            @p_codigo_provincia,
            @p_codigo_canton,
            @p_codigo_distrito,
            @p_detalle_direccion
        );";

            var p = new DynamicParameters();

            // Obligatorios
            p.Add("p_id_tipo_identificacion", dto.IdTipoIdentificacion, DbType.Int16);
            p.Add("p_numero_identificacion", dto.NumeroIdentificacion, DbType.String);
            p.Add("p_nombre", dto.Nombre, DbType.String);
            p.Add("p_apellido1", dto.Apellido1, DbType.String);
            p.Add("p_id_rol", dto.IdRol, DbType.Int16);

            // DATE, no DateTimeOffset ni timestamp
            p.Add("p_fecha_contratacion", dto.FechaContratacion.Date, DbType.Date);
            p.Add("p_apellido2", dto.Apellido2, DbType.String);
            p.Add("p_fecha_nacimiento",
                dto.FechaNacimiento?.Date,
                dto.FechaNacimiento.HasValue ? DbType.Date : DbType.Object);

            p.Add("p_id_genero", dto.IdGenero, DbType.Int16);
            p.Add("p_id_nacionalidad", dto.IdNacionalidad, DbType.Int16);
            p.Add("p_id_estado_civil", dto.IdEstadoCivil, DbType.Int16);
            p.Add("p_id_nivel_educativo", dto.IdNivelEducativo, DbType.Int16);
            p.Add("p_id_ocupacion", dto.IdOcupacion, DbType.Int16);
            p.Add("p_id_tipo_sangre", dto.IdTipoSangre, DbType.Int16);
            p.Add("p_correo", dto.Correo, DbType.String);
            p.Add("p_telefono_celular", dto.TelefonoCelular, DbType.String);
            p.Add("p_telefono_fijo", dto.TelefonoFijo, DbType.String);
            p.Add("p_codigo_provincia", dto.CodigoProvincia, DbType.Int16);
            p.Add("p_codigo_canton", dto.CodigoCanton, DbType.Int16);
            p.Add("p_codigo_distrito", dto.CodigoDistrito, DbType.Int32);
            p.Add("p_detalle_direccion", dto.DetalleDireccion, DbType.String);

            return await conexion.QuerySingleAsync<ColaboradorCreado>(sql, p);
        }
    }
}