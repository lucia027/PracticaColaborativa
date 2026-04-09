using ITV.Models;

namespace ITV.Service.Vehiculos;

/// <summary>
/// Contrato pare el servicio de gestion de vehiculos.
/// </summary>
public interface IVehiculoService {
    
    /// <summary>
    /// Obtiene todos los vehiculos.
    /// </summary>
    /// <returns>Enumerable de vehiculos.</returns>
    IEnumerable<Vehiculo> GetAll();
    
    /// <summary>
    /// Obtiene un vehículo en concreto buscando por su id.
    /// </summary>
    /// <param name="id">Id del vehiculo.</param>
    /// <returns>Vehiculo encontrado.</returns>
    Vehiculo GetById(int id);
    
    /// <summary>
    /// Crea un vehículo nuevo.
    /// </summary>
    /// <param name="vehiculo">Datos del vehículo a crear.</param>
    /// <returns>Vehículo creado.</returns>
    Vehiculo Create(Vehiculo vehiculo);
    
    /// <summary>
    /// Actualiza un vehículo existente.
    /// </summary>
    /// <param name="vehiculo">Datos del vehículo a actualizar.</param>
    /// <param name="id">Id del vehiculo a actualizar.</param>
    /// <returns>Vehiculo actualizado.</returns>
    Vehiculo Update(Vehiculo vehiculo, int id);
    
    /// <summary>
    /// Elimina un vehículo existente.
    /// </summary>
    /// <param name="id">Id del vehículo a eliminar.</param>
    /// <returns>Vehiculo eliminado.</returns>
    Vehiculo Delete(int id);
    
    /// <summary>
    /// Carga los datos de un archivo de texto.
    /// </summary>
    /// <returns>Número de vehiculos cargados.</returns>
    int ImportarDatos();
    
    /// <summary>
    /// Salva los datos existentes en un archivo de texto.
    /// </summary>
    /// <returns>Número de personas exportadas.</returns>
    int ExportarDatos();
    
    /// <summary>
    /// Realiza una copia de seguridad en formato zip de los datos existentes.
    /// </summary>
    /// <returns>Ruta del archivo zip.</returns>
    string SalvarBackup();
    
    /// <summary>
    /// Restaura una copia de seguridad en formato zip ya existente.
    /// </summary>
    /// <returns>Número de registros actualizados.</returns>
    int CargarBackup();
}