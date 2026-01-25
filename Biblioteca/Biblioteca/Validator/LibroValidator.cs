using Biblioteca.Models;

namespace Biblioteca.Validator;

public class LibroValidator : ILibroValidator {
    public Libro Validate(Libro libro) {
        if (string.IsNullOrWhiteSpace(libro.Nombre)) {
            throw new ArgumentException("El nombre no puede estar vacio o en blanco.");
        }

        if (libro.NumeroUsos < 0) {
            throw new ArgumentException("EL número de usos no puede ser negativo.");
        }

        if (libro.NumeroPaginas < 0) {
            throw new ArgumentException("El número de paginas no puede ser negativo.");
        }

        return libro;
    }
}