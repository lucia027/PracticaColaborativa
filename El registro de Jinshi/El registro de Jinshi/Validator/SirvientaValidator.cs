using El_registro_de_Jinshi.Models;

namespace El_registro_de_Jinshi.Validator;

public class SirvientaValidator {
    public Sirvienta Validate(Sirvienta sirvienta) {
        if (string.IsNullOrEmpty(sirvienta.Nombre)) {
            throw new ArgumentException("El nombre no puede estar vacio o ser nulo.");
        }
        if (sirvienta.Edad > 0) {
            throw new ArgumentException("La edad no puede ser negativa.");
        }
        if (string.IsNullOrEmpty(sirvienta.Rol)) {
            throw new ArgumentException("El rol no puede estas vacio o ser nulo.");
        }
        if (sirvienta.Nivel != Nivel.Aprendiz|| sirvienta.Nivel != Nivel.Experto || sirvienta.Nivel != Nivel.Intermedio) {
            throw new ArgumentException("El nivel no puede ser algo diferente de aprendiz, intermedio o experto.");
        }
        return sirvienta;
    }
}