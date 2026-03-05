using Dapper;
using KinderAdminApi.API.Extensiones;
using KinderAdminApi.Aplicacion.Extensiones;
using KinderAdminApi.Compartido.Repuestas;
using KinderAdminApi.Infraestructura.Ayudas;
using KinderAdminApi.Infraestructura.Extensiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Habilita mapeo snake_case -> PascalCase en Dapper
DefaultTypeMap.MatchNamesWithUnderscores = true;

// Registrar capas (Application, Infrastructure)
builder.Services.AgregarAplicacion();
builder.Services.AgregarInfraestructura();

// Controladores y Swagger
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = ctx =>
        {
            var detalle = ctx.ModelState
                .Where(e => e.Value?.Errors.Count > 0)
                .ToDictionary(
                    e => e.Key,
                    e => e.Value!.Errors.Select(x => x.ErrorMessage).ToArray()
                );

            var respuesta = RespuestaGenerica<object>.Fallo(
                "One or more validation errors occurred.",
                new DetalleError(CodigosError.ErrorValidacion, "One or more validation errors occurred.", detalle));

            return new BadRequestObjectResult(respuesta);
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "KinderAPP API",
        Version = "v1",
        Description = "API pública (solo BFF debería exponerse en producción)"
    });
    c.EnableAnnotations();
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Name = "x-api-key",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "API Key para acceso interno"
    });
    c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("ApiKey", document)] = new List<string>()
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        c.IncludeXmlComments(xmlPath);
});
SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "KinderAPP API v1");
    c.RoutePrefix = string.Empty;
});

app.UseGlobalExceptionHandler();
app.UseApiKey();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();