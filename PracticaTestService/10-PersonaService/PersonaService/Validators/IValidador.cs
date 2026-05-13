namespace PersonaService.Validators;

/// <summary>
/// Interfaz para el validador.
/// </summary>
public interface IValidador<T> where T : class
{
    IEnumerable<string> Validar(T entity);
}
