using Practica_Examen_POO.Models;

namespace Practica_Examen_POO.Validator;

public class PaqueteNormalValidator {
    public PaqueteNormal Validate(PaqueteNormal paqueteNormal) {
        if (paqueteNormal.Peso < 0) {
            throw new ArgumentException("El peso del paquete no puede ser negativo.");
        }
        if (string.IsNullOrEmpty(paqueteNormal.CodigoBarras)) {
            throw new ArgumentException("El codigo de barras no puede estar vacio o ser nulo.");
        }
        return paqueteNormal;
    }
}