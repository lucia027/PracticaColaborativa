namespace Biblioteca.Models;

public abstract class Ficha {
    protected static int Contador;
    
    public int Id { get; init; }
    public string Nombre { get; init; }
    public int NumeroUsos { get; set; }

    public Ficha(string nombre, int numeroUsos) {
        Id = Contador++;
        Nombre = nombre;
        NumeroUsos = numeroUsos;
    }
}