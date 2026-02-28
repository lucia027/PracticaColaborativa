using El_registro_de_Jinshi.Models;

namespace El_registro_de_Jinshi.Validator;

public class NobleValidator {
    public Noble Validate(Noble noble) {
        if (string.IsNullOrEmpty(noble.Nombre)) {
            throw new ArgumentException("El nombre no puede estar vacio o ser nulo.");
        }
        if (noble.Edad > 0) {
            throw new ArgumentException("La edad no puede ser negativa.");
        }
        if (string.IsNullOrEmpty(noble.Rol)) {
            throw new ArgumentException("El rol no puede estas vacio o ser nulo.");
        }
        if (noble.Rango != Rango.Alto || noble.Rango != Rango.Medio || noble.Rango != Rango.Bajo) {
            throw new ArgumentException("El rango no puede ser algo diferente de alto, medio o bajo.");
        }
        return noble;
    }
}