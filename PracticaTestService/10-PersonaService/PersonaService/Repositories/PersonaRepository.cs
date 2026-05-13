using PersonaService.Data;
using PersonaService.Factories;
using PersonaService.Models;
using Serilog;

namespace PersonaService.Repositories;

/// <summary>
///     Repositorio implementado con Entity Framework Core InMemory.
/// </summary>
public class PersonaRepository : IPersonaRepository {
    private readonly AppDbContext _context;
    private readonly ILogger _logger = Log.ForContext<PersonaRepository>();

    public PersonaRepository(AppDbContext context) {
        _context = context;
        _context.Database.EnsureCreated();
        SeedData();
    }

    public IEnumerable<Persona> GetAll() {
        _logger.Debug("GetAll ejecutado");
        return _context.Personas.OrderBy(p => p.Id);
    }

    public Persona? GetById(int id) {
        _logger.Debug("GetById({Id}) ejecutado", id);
        return _context.Personas.FirstOrDefault(p => p.Id == id);
    }

    public Persona? Create(Persona persona) {
        persona.CreatedAt = DateTime.Now;
        persona.UpdatedAt = DateTime.Now;
        persona.IsDeleted = false;

        _context.Personas.Add(persona);
        _context.SaveChanges();

        _logger.Information("Create: Persona {Id} creada - {Nombre}", persona.Id, persona.Nombre);
        return persona;
    }

    public Persona? Update(int id, Persona persona) {
        var existing = GetById(id);
        if (existing == null) return null;

        existing.Nombre = persona.Nombre;
        existing.Email = persona.Email;
        existing.UpdatedAt = DateTime.Now;

        _context.SaveChanges();
        _logger.Information("Update: Persona {Id} actualizada - {Nombre}", id, existing.Nombre);
        return existing;
    }

    public Persona? Delete(int id, bool logical = true) {
        var persona = GetById(id);
        if (persona == null) return null;

        persona.IsDeleted = true;
        persona.DeletedAt = DateTime.Now;
        persona.UpdatedAt = DateTime.Now;

        if (!logical) _context.Personas.Remove(persona);

        _context.SaveChanges();
        _logger.Information("Persona {Id} eliminada (logical={Logical})", id, logical);
        return persona;
    }

    public Persona? FindByEmail(string email) {
        _logger.Debug("FindByEmail({Email}) ejecutado", email);
        return _context.Personas.FirstOrDefault(p => p.Email == email);
    }

    private void SeedData() {
        var list = PersonaFactory.Seed().ToList();
        _context.Personas.AddRange(list);
        _context.SaveChanges();
        _logger.Information("Seed data cargada: {Count} registros", list.Count());
    }
}