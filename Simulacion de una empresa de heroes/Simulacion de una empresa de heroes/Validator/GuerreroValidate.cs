using Simulacion_de_una_empresa_de_heroes.Models;

namespace Simulacion_de_una_empresa_de_heroes.Validator;

public class GuerreroValidate : IValidator<Heroe> {
    public IEnumerable<string> Validate(Heroe entidad) {
        var errores = new List<string>();
        
        if (entidad is not Guerrero guerrero) {
            errores.Add("El heroe no es un guerrero.");
            return errores;
        }

        if (string.IsNullOrWhiteSpace(guerrero.Nombre)) {
            errores.Add("El nombre del guerrero no puede estar en blanco");
        }

        if (guerrero.PoderBase < 0) {
            errores.Add("El poder base no puede ser negativo.");
        }
        
        if (guerrero.Nivel < 0) {
            errores.Add("El nivel no puede ser negativo.");
        }
        
        if (guerrero.Experiencia < 0) {
            errores.Add("La experiencia no puede ser negativa.");
        }
        
        if (guerrero.Energia < 0) {
            errores.Add("La energia no puede ser negativa");
        }
        
        if (guerrero.Fuerza < 0) {
            errores.Add("La fuerza no puede ser negativa.");
        }

        return errores;
    }
}