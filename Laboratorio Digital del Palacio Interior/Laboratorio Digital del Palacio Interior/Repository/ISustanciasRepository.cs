using Laboratorio_Digital_del_Palacio_Interior.Models;
using Laboratorio_Digital_del_Palacio_Interior.Repository.Common;

namespace Laboratorio_Digital_del_Palacio_Interior.Repository;

/// <summary>
/// Contrato especializado para la gestion de sustancias.
/// </summary>
public interface ISustanciasRepository : ICrudRepository<int, Sustancia> {
    
    /// <summary>
    /// Vacia por completo el almacenamiento.
    /// </summary>
    /// <returns>True al eliminarlo correctamente.</returns>
    bool DeleteAll();
}