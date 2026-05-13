using PersonaService.Models;
using PersonaService.Repositories;
using PersonaService.Validators;
using PersonaService.Cache;
using PersonaService.Exceptions;

namespace PersonaService.Services;

/// <summary>
/// Interfaz para el servicio de personas.
/// </summary>
public interface IPersonaService
{
    IEnumerable<Persona> GetAll();
    Persona? GetById(int id);
    Persona Create(Persona persona);
    Persona Update(int id, Persona persona);
    Persona Delete(int id, bool logical = true);
}
