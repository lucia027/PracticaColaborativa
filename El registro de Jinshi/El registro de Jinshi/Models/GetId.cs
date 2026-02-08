namespace El_registro_de_Jinshi.Models;

public class GetId {
    public static int Contador = 0;

    public static int GetNewId() {
        return Contador++;
    }
}