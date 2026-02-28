namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public class GetId {
    private static int _contador = 0;

    public static int GetNewId() {
        return _contador++;
    }
}