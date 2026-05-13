using Microsoft.EntityFrameworkCore;
using PersonaService.Models;
using PersonaService.Repositories;
using PersonaService.Services;
using PersonaService.Validators;
using PersonaService.Cache;
using PersonaService.Data;
using PersonaService.Exceptions;
using Serilog;
using Service = PersonaService.Services.PersonaService;

// Configuración de Serilog
var loggerConfiguration = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(
        outputTemplate: "{Timestamp:HH:mm:ss.fff} [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

Log.Logger = loggerConfiguration;

Console.WriteLine("=== Persona Service con Validador, Cache y Excepciones ===");
Console.WriteLine();

// Crear DbContext con SQLite en memoria
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseInMemoryDatabase(databaseName: "personas_db")
    .Options;

using var context = new AppDbContext(options);

// Inyección manual de dependencias
IPersonaRepository repository = new PersonaRepository(context);
IValidador<Persona> validador = new ValidadorPersona();
ICache<int, Persona> cache = new LruCache<int, Persona>(3);
IPersonaService service = new Service(repository, validador, cache);

// ==================== GET ALL ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== GET ALL (Seed Data) ===");
Console.WriteLine("═══════════════════════════════════════════");
foreach (var p in service.GetAll())
    Console.WriteLine($"  {p}");

// ==================== GET BY ID - EXISTE ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== GET BY ID(1) - Existe ===");
Console.WriteLine("═══════════════════════════════════════════");
var persona1 = service.GetById(1);
Console.WriteLine($"  Resultado: {(persona1 != null ? persona1.ToString() : "NULL")}");

// ==================== GET BY ID - NO EXISTE ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== GET BY ID(999) - NO Existe ===");
Console.WriteLine("═══════════════════════════════════════════");
try {
    service.GetById(999);
    Console.WriteLine($"  ✗ Error: Debería haber lanzado excepción");
}
catch (PersonaException.NotFound ex)
{
    Console.WriteLine($"  ✓ Excepción capturada: {ex.Message}");
}

// ==================== GET BY ID - DESDE CACHE ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== GET BY ID(1) - Desde Cache ===");
Console.WriteLine("═══════════════════════════════════════════");
var persona1Cached = service.GetById(1);
Console.WriteLine($"  Resultado: {(persona1Cached != null ? persona1Cached.ToString() : "NULL")}");

// ==================== CREATE - VALIDO ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== CREATE - Válido ===");
Console.WriteLine("═══════════════════════════════════════════");
try
{
    var nueva = new Persona { Nombre = "Carlos Ruiz", Email = "carlos@correo.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false };
    var created = service.Create(nueva);
    Console.WriteLine($"  ✓ Creado: {created}");
}
catch (PersonaException.Validation ex)
{
    Console.WriteLine($"  ✗ Error de validación: {ex.Message}");
}

// ==================== CREATE - EMAIL DUPLICADO ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== CREATE - Email Duplicado ===");
Console.WriteLine("═══════════════════════════════════════════");
try
{
    var dup = new Persona { Nombre = "Ana Duplicate", Email = "ana@correo.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false };
    service.Create(dup);
    Console.WriteLine($"  ✗ Error: Debería haber lanzado excepción");
}
catch (PersonaException.AlreadyExists ex)
{
    Console.WriteLine($"  ✓ Excepción capturada: {ex.Message}");
}

// ==================== CREATE - VALIDACION FALLIDA ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== CREATE - Validación Fallida ===");
Console.WriteLine("═══════════════════════════════════════════");
try
{
    var inv = new Persona { Nombre = "", Email = "invalido", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false };
    service.Create(inv);
    Console.WriteLine($"  ✗ Error: Debería haber lanzado excepción");
}
catch (PersonaException.Validation ex)
{
    Console.WriteLine($"  ✓ Excepción capturada: {ex.Message}");
    foreach (var err in ex.Errores)
        Console.WriteLine($"    - {err}");
}

// ==================== UPDATE - VALIDO ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== UPDATE - Válido ===");
Console.WriteLine("═══════════════════════════════════════════");
try
{
    var updated = service.Update(1, new Persona { Nombre = "Ana Actualizada", Email = "ana.actualizada@correo.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false });
    Console.WriteLine($"  ✓ Actualizado: {updated}");
}
catch (PersonaException.NotFound ex)
{
    Console.WriteLine($"  ✗ Error: {ex.Message}");
}

// ==================== UPDATE - NO EXISTE ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== UPDATE - No Existe ===");
Console.WriteLine("═══════════════════════════════════════════");
try
{
    service.Update(999, new Persona { Nombre = "NoExiste", Email = "noexiste@correo.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false });
    Console.WriteLine($"  ✗ Error: Debería haber lanzado excepción");
}
catch (PersonaException.NotFound ex)
{
    Console.WriteLine($"  ✓ Excepción capturada: {ex.Message}");
}

// ==================== UPDATE - EMAIL DUPLICADO ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== UPDATE - Email Duplicado ===");
Console.WriteLine("═══════════════════════════════════════════");
try
{
    // Intentar cambiar el email de persona 2 al email de persona 1
    service.Update(2, new Persona { Nombre = "Juan Perez", Email = "ana@correo.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = false });
    Console.WriteLine($"  ✗ Error: Debería haber lanzado excepción");
}
catch (PersonaException.AlreadyExists ex)
{
    Console.WriteLine($"  ✓ Excepción capturada: {ex.Message}");
}

// ==================== DELETE LOGICO - EXISTE ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== DELETE LÓGICO(2) - Existe ===");
Console.WriteLine("═══════════════════════════════════════════");
try
{
    var deleted = service.Delete(2);
    Console.WriteLine($"  ✓ Eliminado (lógico): {deleted}");
}
catch (PersonaException.NotFound ex)
{
    Console.WriteLine($"  ✗ Error: {ex.Message}");
}

// ==================== DELETE LOGICO - NO EXISTE ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== DELETE LÓGICO(999) - No Existe ===");
Console.WriteLine("═══════════════════════════════════════════");
try
{
    service.Delete(999);
    Console.WriteLine($"  ✗ Error: Debería haber lanzado excepción");
}
catch (PersonaException.NotFound ex)
{
    Console.WriteLine($"  ✓ Excepción capturada: {ex.Message}");
}

// ==================== DELETE FISICO ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== DELETE FÍSICO(3) ===");
Console.WriteLine("═══════════════════════════════════════════");
try
{
    var deletedFisico = service.Delete(3, false);
    Console.WriteLine($"  ✓ Eliminado (físico): {deletedFisico}");
}
catch (PersonaException.NotFound ex)
{
    Console.WriteLine($"  ✗ Error: {ex.Message}");
}

// ==================== GET ALL FINAL ====================
Console.WriteLine();
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("=== GET ALL FINAL ===");
Console.WriteLine("═══════════════════════════════════════════");
foreach (var p in service.GetAll())
    Console.WriteLine($"  {p}");

Console.WriteLine();
Console.WriteLine("=== Fin ===");

Log.CloseAndFlush();
