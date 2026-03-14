namespace Laboratorio_Digital_del_Palacio_Interior.Models;
/// <summary>
/// Gestión de los ID.
/// </summary>
public class GetId {
    private static int _contador = 0;

    /// <summary>
    /// Devuelve un ID nuevo y único.
    /// </summary>
    /// <returns>Id nuevo</returns>
    public static int GetNewId() {
        return _contador++;
    }
}