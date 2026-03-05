using KinderAdminApi.Compartido.Repuestas;

namespace KinderAdminApi.API.Extensiones
{
    public static class ExtencionLlaveApi
    {
        public static IApplicationBuilder UseApiKey(this IApplicationBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path.StartsWithSegments("/swagger"))
                {
                    await next();
                    return;
                }

                var validKeys = ctx.RequestServices
                    .GetRequiredService<IConfiguration>()
                    .GetSection("ApiKeys")
                    .Get<string[]>();

                if (!ctx.Request.Headers.TryGetValue("x-api-key", out var key)
                    || validKeys == null
                    || !validKeys.Contains(key.ToString()))
                {
                    ctx.Response.StatusCode = 401;
                    ctx.Response.ContentType = "application/json";
                    await ctx.Response.WriteAsJsonAsync(
                        RespuestaGenerica<object>.Fallo(
                            "No autorizado",
                            new DetalleError(CodigosError.Prohibido, "Invalid or missing API key.")));
                    return;
                }

                await next();
            });
            return app;
        }
    }
}
