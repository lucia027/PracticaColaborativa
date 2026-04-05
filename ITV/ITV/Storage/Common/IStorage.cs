namespace ITV.Storage.Common;

public interface IStorage<T> {
    /// <summary>
    /// Carga los datos del archivo con la ruta especificada.
    /// </summary>
    /// <param name="path">Ruta del archivo de datos.</param>
    /// <returns>Enumerable de los datos cargados.</returns>
    IEnumerable<T> Cargar(string path);
    
    /// <summary>
    /// Salva los datos en un archivo con la ruta especificada.
    /// </summary>
    /// <param name="items">Datos a salvar.</param>
    /// <param name="path">Ruta donde estara el archivo.</param>
    void Salvar(IEnumerable<T> items, string path);
}