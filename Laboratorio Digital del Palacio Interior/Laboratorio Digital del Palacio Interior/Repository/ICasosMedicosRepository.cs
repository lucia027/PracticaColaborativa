using Laboratorio_Digital_del_Palacio_Interior.Models;
using Laboratorio_Digital_del_Palacio_Interior.Repository.Common;

namespace Laboratorio_Digital_del_Palacio_Interior.Repository;

/// <summary>
/// Contrato especializado para la gestion de casos médicos.
/// </summary>
public interface ICasosMedicosRepository : ICrudRepository<int, CasoMedico> {
    
    /// <summary>
    /// Vacia por completo el almacenamiento.
    /// </summary>
    /// <returns>True al eliminarlo correctamente.</returns>
    bool DeleteAll();
}