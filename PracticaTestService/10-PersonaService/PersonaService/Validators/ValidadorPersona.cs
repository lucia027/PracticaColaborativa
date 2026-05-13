using PersonaService.Models;
using Serilog;

namespace PersonaService.Validators;

/// <summary>
/// Validador para la entidad Persona.
/// </summary>
public class ValidadorPersona : IValidador<Persona>
{
    private readonly ILogger _logger = Log.ForContext<ValidadorPersona>();

    public IEnumerable<string> Validar(Persona persona)
    {
        _logger.Debug("Validando persona: {Nombre}, {Email}", persona.Nombre, persona.Email);
        
        var errores = new List<string>();

        if (string.IsNullOrWhiteSpace(persona.Nombre))
            errores.Add("El nombre es obligatorio.");
        else if (persona.Nombre.Length < 2)
            errores.Add("El nombre debe tener al menos 2 caracteres.");
        else if (persona.Nombre.Length > 100)
            errores.Add("El nombre no puede exceder 100 caracteres.");

        if (!string.IsNullOrWhiteSpace(persona.Email) && !persona.Email.Contains('@'))
            errores.Add("El email debe ser válido.");

        if (errores.Any())
            _logger.Warning("Validación fallida: {Errores}", string.Join(", ", errores));
        else
            _logger.Debug("Validación correcta");

        return errores;
    }
}
