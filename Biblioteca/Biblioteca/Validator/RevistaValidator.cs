using Biblioteca.Models;

namespace Biblioteca.Validator;

public class RevistaValidator : IRevistaValidator {
    public Revista Validate(Revista revista) {
        if (string.IsNullOrWhiteSpace(revista.Nombre)) {
            throw new ArgumentException("El nombre no puede estar vacio o en blanco.");
        }

        if (revista.NumeroUsos < 0) {
            throw new ArgumentException("El número de usos no puede ser negativo.");
        }

        if (revista.Categoria != CategoriaRevista.Cotilleo && revista.Categoria != CategoriaRevista.Deportes) {
            throw new ArgumentException("La categoria de la revista solo pude ser de Cotilleo o de Deportes.");
        }

        return revista;
    }
}