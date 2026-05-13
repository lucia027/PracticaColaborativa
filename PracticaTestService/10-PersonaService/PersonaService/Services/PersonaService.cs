using PersonaService.Cache;
using PersonaService.Exceptions;
using PersonaService.Models;
using PersonaService.Repositories;
using PersonaService.Validators;
using Serilog;

namespace PersonaService.Services;

/// <summary>
///     Servicio para la gestión de personas con validación, caché y excepciones.
/// </summary>
public class PersonaService(
    IPersonaRepository repository,
    IValidador<Persona> validador,
    ICache<int, Persona> cache
) : IPersonaService {
    private readonly ILogger _logger = Log.ForContext<PersonaService>();

    public IEnumerable<Persona> GetAll() {
        _logger.Information("Obteniendo todas las personas");
        return repository.GetAll();
    }

    public Persona GetById(int id) {
        _logger.Information("Buscando persona con Id={Id}", id);

        if (cache.Get(id) is { } cached) {
            _logger.Information("[CACHE] Persona {Id} encontrada en caché: {Persona}", id, cached);
            return cached;
        }

        if (repository.GetById(id) is { } persona) {
            cache.Add(id, persona);
            _logger.Information("[CACHE] Persona {Id} añadida a caché: {Persona}", id, persona);
            return persona;
        }

        _logger.Warning("Persona con Id={Id} no encontrada", id);
        throw new PersonaException.NotFound(id);
    }

    public Persona Create(Persona persona) {
        _logger.Information("Creando persona: {Nombre}, {Email}", persona.Nombre, persona.Email);

        if (validador.Validar(persona).Any()) {
            var errores = validador.Validar(persona);
            _logger.Error("Error de validación al crear persona: {Errores}", string.Join(", ", errores));
            throw new PersonaException.Validation(errores);
        }

        if (repository.FindByEmail(persona.Email) is { } existente) {
            _logger.Error("Conflicto: El email {Email} ya está registrado con Id={Id}", persona.Email, existente.Id);
            throw new PersonaException.AlreadyExists(persona.Email);
        }

        var created = repository.Create(persona);

        if (created is { } createdValue) _logger.Information("Persona creada correctamente: {Persona}", createdValue);

        return created!;
    }

    public Persona Update(int id, Persona persona) {
        _logger.Information("Actualizando persona con Id={Id}", id);

        if (repository.GetById(id) is not { } existing) {
            _logger.Error("No se puede actualizar: Persona con Id={Id} no encontrada", id);
            throw new PersonaException.NotFound(id);
        }

        if (validador.Validar(persona).Any()) {
            var errores = validador.Validar(persona);
            _logger.Error("Error de validación al actualizar persona: {Errores}", string.Join(", ", errores));
            throw new PersonaException.Validation(errores);
        }

        if (repository.FindByEmail(persona.Email) is { } duplicateEmail && duplicateEmail.Id != id) {
            _logger.Error("Conflicto: El email {Email} ya está registrado con Id={Id}", persona.Email,
                duplicateEmail.Id);
            throw new PersonaException.AlreadyExists(persona.Email);
        }

        var updated = repository.Update(id, persona);

        if (updated is { } updatedValue) {
            cache.Remove(id);
            _logger.Information("Persona actualizada correctamente: {Persona}", updatedValue);
        }

        return updated!;
    }

    public Persona Delete(int id, bool logical = true) {
        _logger.Information("Eliminando persona con Id={Id} (logical={Logical})", id, logical);

        if (repository.GetById(id) is not { } existing) {
            _logger.Error("No se puede eliminar: Persona con Id={Id} no encontrada", id);
            throw new PersonaException.NotFound(id);
        }

        var deleted = repository.Delete(id, logical);

        if (deleted is { } deletedValue) {
            cache.Remove(id);
            _logger.Information("Persona eliminada correctamente: {Persona}", deletedValue);
        }

        return deleted!;
    }
}