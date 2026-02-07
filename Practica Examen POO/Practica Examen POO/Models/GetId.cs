namespace Practica_Examen_POO.Models;

public class GetId {
    public static int Contador { get; set; } = 0;

    public static int  GetNewId() {
        return Contador++;
    }
}