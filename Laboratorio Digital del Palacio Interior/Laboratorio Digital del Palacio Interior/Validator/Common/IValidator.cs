using System.Collections.Generic;

namespace Laboratorio_Digital_del_Palacio_Interior.Validator.Common;

/// <summary>
/// Contrato generico para validar entidades.
/// </summary>
/// <typeparam name="T">Tipo de la entidad a validar.</typeparam>
public interface IValidator<T> {
    
    /// <summary>
    /// Valída si la entidad proporcionada cumple los requisitos del sistema.
    /// </summary>
    /// <param name="entity">Entidad proporcionada para validar.</param>
    /// <returns>Enumerable de los errores acumulados en el proceso de validacion de la entidad.</returns>
    IEnumerable<string> Validate(T entity);
}