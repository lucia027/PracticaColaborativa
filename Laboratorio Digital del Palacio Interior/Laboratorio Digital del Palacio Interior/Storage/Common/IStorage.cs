namespace Laboratorio_Digital_del_Palacio_Interior.Storage.Common;

/// <summary>
/// Contrato para el almacenamiento de datos en un archivo.
/// </summary>
/// <typeparam name="T">Tipo de dato.</typeparam>
public interface IStorage<T> {
    
    /// <summary>
    /// Salva una coleccion de los elementos en el archivo.
    /// </summary>
    /// <param name="items">Coleccion de elementos.</param>
    /// <param name="path">Ruta del archivo.</param>
    public void Salvar(IEnumerable<T> items, string path);
    
    /// <summary>
    /// Carga una coleccion de elementos de un archivo.
    /// </summary>
    /// <param name="path">Ruta del archivo</param>
    /// <returns>Coleccion de elementos.</returns>
    public IEnumerable<T> Cargar(string path);
}