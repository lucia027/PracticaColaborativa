using System;
using System.Collections.Generic;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;
using Laboratorio_Digital_del_Palacio_Interior.Validator.Common;

namespace Laboratorio_Digital_del_Palacio_Interior.Validator;

public class AfrodisiacoValidator : IValidator<Sustancia> {
    public IEnumerable<string> Validar(Sustancia entity) {
        var errores = new List<string>();

        if (entity is not Afrodisiaco afrodisiaco) {
            errores.Add("ERROR - La sustancia no es un afrodisiaco.");
            return errores;
        }
        
        if (string.IsNullOrEmpty(afrodisiaco.Nombre)) {
            errores.Add("ERROR - El nombre no puede ser nulo o estar vacio.");
        }

        if (string.IsNullOrEmpty(afrodisiaco.Descripcion)) {
            errores.Add("ERROR - La descripción no puede ser nulo o estar vacia.");
        }
        
        if (afrodisiaco.Precio < 0) {
            errores.Add("ERROR - El precio no puede ser negativo.");
        }
        
        if (afrodisiaco.Disponibilidad < 0) {
            errores.Add("ERROR - La disponibilidad no puede ser negativa.");
        }

        if (!Enum.IsDefined(typeof(Peligro), afrodisiaco.NivelPeligro)) {
            errores.Add("ERROR - El peligro no puede ser diferente de nulo, bajo, medio o alto.");
        }
        
        if (afrodisiaco.IntensidadEfecto < 0) {
            errores.Add("ERROR - La intensidad del efecto no puede ser negativa.");
        }
        
        if (afrodisiaco.Duracion < 0) {
            errores.Add("ERROR - La duración no puede ser negativa.");
        }

        if (string.IsNullOrEmpty(afrodisiaco.ContraIndicaciones)) {
            errores.Add("ERROR - Las contraindicaciones no pueden ser nulas o estar vacias.");
        }
        
        if (string.IsNullOrEmpty(afrodisiaco.RiegosUso)) {
            errores.Add("ERROR - Los riesgos de uso excesivo no pueden ser nulo estar vacios.");
        }
        
        return errores;
    }
}