namespace Biblioteca.Models;

public class Revista : Ficha {
    public CategoriaRevista Categoria { get; set; }
        
    public Revista(string nombre, int numeroUsos, CategoriaRevista categoria) : base(nombre, numeroUsos) {
        Id = Contador++;
        Nombre = nombre;
        NumeroUsos = numeroUsos;
        Categoria = categoria;
    }
}