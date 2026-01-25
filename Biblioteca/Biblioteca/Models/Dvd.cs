namespace Biblioteca.Models;

public class Dvd : Ficha {
    public int Minutos { get; init; }

    public Dvd(string nombre, int numeroUsos, int minutos) : base(nombre, numeroUsos) {
        Id = Contador++;
        Nombre = nombre;
        NumeroUsos = numeroUsos;
        Minutos = minutos;
    }
}