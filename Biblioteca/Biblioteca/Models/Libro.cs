namespace Biblioteca.Models;

public class Libro : Ficha {
    public int NumeroPaginas { get; init; }

    public Libro(string nombre, int numeroUsos, int numeroPaginas) : base(nombre, numeroUsos) {
        Id = Contador++;
        Nombre = nombre;
        NumeroUsos = numeroUsos;
        NumeroPaginas = numeroPaginas;
    }
}