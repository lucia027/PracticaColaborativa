using System.Runtime.Serialization;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;
using Laboratorio_Digital_del_Palacio_Interior.Validator.Common;

namespace Laboratorio_Digital_del_Palacio_Interior.Validator;

public class MedicinaValidator : IValidator<Sustancia> {
    public IEnumerable<string> Validar(Sustancia entity) {
        var errores = new List<string>();

        if (entity is not Medicina medicina) {
            errores.Add("ERROR - La sustancia no es una medicina.");
            return errores;
        }
        
        if (string.IsNullOrEmpty(medicina.Nombre)) {
            errores.Add("ERROR - El nombre no puede ser nulo o estar vacio.");
        }

        if (string.IsNullOrEmpty(medicina.Descripcion)) {
            errores.Add("ERROR - La descripción no puede ser nulo o estar vacia.");
        }
        
        if (medicina.Precio < 0) {
            errores.Add("ERROR - El precio no puede ser negativo.");
        }
        
        if (medicina.Disponibilidad < 0) {
            errores.Add("ERROR - La disponibilidad no puede ser negativa.");
        }

        if (!Enum.IsDefined(typeof(Peligro), medicina.NivelPeligro)) {
            errores.Add("ERROR - El peligro no puede ser diferente de nulo, bajo, medio o alto.");
        }

        if (string.IsNullOrEmpty(medicina.Sintoma)) {
            errores.Add("ERROR - El sintoma no puede ser nulo o estar vacio.");
        }

        if (medicina.DosisRecomendada < 0) {
            errores.Add("ERROR - La dosis recomendada no puede ser negativa.");
        }

        if (string.IsNullOrEmpty(medicina.EfectosSecundarios)) {
            errores.Add("ERROR - Los efectos secundarios no puede ser nulo o estar vacios.");
        }

        if (medicina.TiempoEfecto < 0) {
            errores.Add("ERROR - El tiempo de efecto no puede ser negativo.");
        }
        return errores;
    }
}