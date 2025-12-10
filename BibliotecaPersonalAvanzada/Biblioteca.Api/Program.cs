using Biblioteca.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Inyección de dependencias para el DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(connectionString));

// Servicios estándar del API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// =========================================================================
// CÓDIGO CLAVE: CONEXIÓN y CREACIÓN AUTOMÁTICA (SIN MIGRACIONES)
// =========================================================================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<BibliotecaContext>();

        // **Esta línea crea la BD y el esquema la primera vez que se ejecuta el API.**
        context.Database.EnsureCreated();
        Console.WriteLine("Base de datos creada o existente en SQLEXPRESS.");
    }
    catch (Exception ex)
    {
        // Manejo de errores si la conexión falla (ej. servidor no está corriendo)
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al intentar crear/conectar la base de datos.");
    }
}
// =========================================================================


// Configuración del Pipeline del API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();