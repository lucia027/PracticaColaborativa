using Simulacion_de_una_empresa_de_heroes.Models;

namespace Simulacion_de_una_empresa_de_heroes.Validator;

public class SanadorValidate : IValidator<Heroe> {
    public IEnumerable<string> Validate(Heroe entidad) {
        var errores = new List<string>();
        
        if (entidad is not Sanador sanador) {
            errores.Add("El heroe no es un Sanador.");
            return errores;
        }

        if (string.IsNullOrWhiteSpace(sanador.Nombre)) {
            errores.Add("El nombre del sanador no puede estar en blanco");
        }

        if (sanador.PoderBase < 0) {
            errores.Add("El poder base no puede ser negativo.");
        }
        
        if (sanador.Nivel < 0) {
            errores.Add("El nivel no puede ser negativo.");
        }
        
        if (sanador.Experiencia < 0) {
            errores.Add("La experiencia no puede ser negativa.");
        }
        
        if (sanador.Energia < 0) {
            errores.Add("La energia no puede ser negativa");
        }
        
        if (sanador.CapacidadCuracion < 0) {
            errores.Add("La capacidad de curacion no puede ser negativa.");
        }

        return errores;
    }
}