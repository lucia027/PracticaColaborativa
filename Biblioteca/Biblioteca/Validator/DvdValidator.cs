using Biblioteca.Models;

namespace Biblioteca.Validator;

public class DvdValidator : IDvdValidator {
    public Dvd Validate(Dvd dvd) {
        if (string.IsNullOrWhiteSpace(dvd.Nombre)) {
            throw new ArgumentException("El nombre no puede ser nulo o estar en blanco.");
        }

        if (dvd.NumeroUsos < 0) {
            throw new ArgumentException("El número de usos no puede ser negativo.");
        }

        if (dvd.Minutos < 0) {
            throw new ArgumentException("Los minutos no pueden estar en negativo.");
        }

        return dvd;
    }
}