using PersonaService.Models;
using PersonaService.Repositories;

namespace PersonaService.Repositories;

/// <summary>
/// Interfaz específica para el repositorio de personas.
/// </summary>
public interface IPersonaRepository : ICrudRepository<int, Persona>
{
    Persona? FindByEmail(string email);
}
