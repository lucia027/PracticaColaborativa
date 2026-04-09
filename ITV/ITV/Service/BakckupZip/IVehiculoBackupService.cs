using ITV.Models;

namespace ITV.Service.BakckupZip;

/// <summary>
/// Contrato para el servicio de backup.
/// </summary>
public interface IVehiculoBackupService {
    
    /// <summary>
    /// Genera una copia de seguridad de los datos proporcionados.
    /// </summary>
    /// <param name="vehiculos">Datos a guardar.</param>
    /// <returns>Ruta del archivo con la copia de seguridad.</returns>
    string RealizarBackup(IEnumerable<Vehiculo> vehiculos);
    
    /// <summary>
    /// Carga una copia de seguridad específica.
    /// </summary>
    /// <param name="backup">Ruta de la copia de seguridad a cargar.</param>
    /// <returns>Enumerable de los datos cargados.</returns>
    IEnumerable<Vehiculo> RestaurarBackup(string backup);
}