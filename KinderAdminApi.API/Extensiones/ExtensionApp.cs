using KinderAdminApi.Compartido.Extensiones;
using KinderAdminApi.Compartido.Repuestas;
using Microsoft.AspNetCore.Diagnostics;
using Npgsql;

namespace KinderAdminApi.API.Extensiones
{
    public static class ExtensionApp
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(err => err.Run(async ctx =>
            {
                var ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;
                ctx.Response.ContentType = "application/json";

                ctx.Response.StatusCode = ex switch
                {
                    NoAutorizadoException => StatusCodes.Status401Unauthorized,
                    NoEncontradoException => StatusCodes.Status404NotFound,
                    ArgumentException => StatusCodes.Status400BadRequest,
                    NpgsqlException => StatusCodes.Status503ServiceUnavailable,
                    _ => StatusCodes.Status500InternalServerError
                };

                var response = ex switch
                {
                    NoAutorizadoException nae => RespuestaGenerica<object>.Fallo(
                        nae.Message,
                        new DetalleError(nae.Codigo, nae.Message),
                        EstadoRespuesta.NoAutorizado),

                    NoEncontradoException nfe => RespuestaGenerica<object>.Fallo(
                        nfe.Message,
                        new DetalleError(nfe.Codigo, nfe.Message),
                        EstadoRespuesta.NoEncontrado),

                    ArgumentException ae => RespuestaGenerica<object>.Fallo(
                        ae.Message,
                        new DetalleError(CodigosError.ErrorValidacion, ae.Message),
                        EstadoRespuesta.ErrorValidacion),

                    NpgsqlException npe => RespuestaGenerica<object>.Fallo(
                        "Error de base de datos.",
                        new DetalleError(CodigosError.ErrorInterno, npe.Message),
                        EstadoRespuesta.Fallido),

                    _ => RespuestaGenerica<object>.DesdeExcepcion(ex!)
                };

                await ctx.Response.WriteAsJsonAsync(response);
            }));

            return app;
        }
    }
}