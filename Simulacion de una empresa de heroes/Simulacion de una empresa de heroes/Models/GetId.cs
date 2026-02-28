namespace Simulacion_de_una_empresa_de_heroes.Models;

public class GetId {
    private static int _contador { get; set; } = 0;

    public static int GetNewId() {
        return _contador++;
    }
}