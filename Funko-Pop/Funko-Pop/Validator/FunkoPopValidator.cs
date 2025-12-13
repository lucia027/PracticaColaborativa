using Funko_Pop.Models;

namespace Funko_Pop.Validator;

/// <summary>
///  Clase encargada de validar los funko pops
/// </summary>
public class FunkoPopValidator {
    
    /// <summary>
    /// Función encargada de validar los atributos de FunkoPops.
    /// </summary>
    /// <param name="funko">Objeto FunkoPop a validar</param>
    /// <returns>Devuelve el funko en caso de pasar la validación</returns>
    public FunkoPop FunkoValidate(FunkoPop funko) {
        if (string.IsNullOrWhiteSpace(funko.Nombre)) {
            throw new ArgumentException("El nombre no puede ser nulo o estar vacio.");
        }
        if (funko.Precio < 0) {
            throw new ArgumentException("El precio no puede ser negativo");
        }
        if (funko.Categoria != FunkoPop.Tipo.Anime || funko.Categoria != FunkoPop.Tipo.Disney || funko.Categoria != FunkoPop.Tipo.Superheroe) {
            throw new ArgumentException("La categoria solo puede ser: Anime, Disney o Superheroe.");
        }

        return funko;
    }
}