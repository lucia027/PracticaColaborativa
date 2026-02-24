using Simulacion_de_una_empresa_de_heroes.Models;

namespace Simulacion_de_una_empresa_de_heroes.Validator;

public class EstrategaValidate : IValidator<Heroe> {
    public IEnumerable<string> Validate(Heroe entidad) {
        var errores = new List<string>();
        
        if (entidad is not Estratega estratega) {
            errores.Add("El heroe no es un estratega.");
            return errores;
        }

        if (string.IsNullOrWhiteSpace(estratega.Nombre)) {
            errores.Add("El nombre del estratega no puede estar en blanco");
        }

        if (estratega.PoderBase < 0) {
            errores.Add("El poder base no puede ser negativo.");
        }
        
        if (estratega.Nivel < 0) {
            errores.Add("El nivel no puede ser negativo.");
        }
        
        if (estratega.Experiencia < 0) {
            errores.Add("La experiencia no puede ser negativa.");
        }
        
        if (estratega.Energia < 0) {
            errores.Add("La energia no puede ser negativa");
        }
        
        if (estratega.NivelAnalisis < 0) {
            errores.Add("El nivel de analista no puede ser negativo.");
        }

        return errores;
    }
}