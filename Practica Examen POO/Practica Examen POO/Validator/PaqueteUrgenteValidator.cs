using Practica_Examen_POO.Models;

namespace Practica_Examen_POO.Validator;

public class PaqueteUrgenteValidator {
    public PaqueteUrgente Validate(PaqueteUrgente paqueteUrgente) {
        if (paqueteUrgente.Peso < 0) {
            throw new ArgumentException("El peso no puede ser negativo.");
        }
        if (string.IsNullOrEmpty(paqueteUrgente.CodigoBarras)) {
            throw new ArgumentException("El codigo de barras no puede estar vacio o ser nulo.");
        }
        if (paqueteUrgente.CosteSeguro < 0.00) {
            throw new ArgumentException("El coste del seguro no puede ser negativo");
        }

        return paqueteUrgente;
    }
}