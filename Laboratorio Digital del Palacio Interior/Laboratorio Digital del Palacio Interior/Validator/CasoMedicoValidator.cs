using System;
using System.Collections.Generic;
using System.Linq;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;
using Laboratorio_Digital_del_Palacio_Interior.Validator.Common;

namespace Laboratorio_Digital_del_Palacio_Interior.Validator;

public class CasoMedicoValidator : IValidator<CasoMedico> {
    public IEnumerable<string> Validar(CasoMedico entity ) {
        var errores = new List<string>();

        if (string.IsNullOrEmpty(entity.Sintomas)) {
            errores.Add("ERROR - Los sintomas no pueden ser nulo o estar vacio.");
        }

        if (!Enum.IsDefined(typeof(Gravedad), entity.Gravedad)) {
            errores.Add("ERROR - La gravedad solo puede ser nulo, leve, moderado o grave.");
        }

        if (!Enum.IsDefined(typeof(CausaSospecha), entity.CausaSospecha)) {
            errores.Add("ERROR - La gravedad solo puede ser enfermedad, veneno, desconocida.");
        }
        
        if(!entity.SustanciasSospechosas.Any()){
            errores.Add("ERROR - La colección de sustancias sospechosas esta vacia.");
        }

        if(!entity.Tratamientos.Any()){
            errores.Add("ERROR - La colección de tratamientos esta vacia.");
        }

        if (!Enum.IsDefined(typeof(EstadoCasoMedico), entity.Estado)) {
            errores.Add("ERROR - El estado del caso medico solo puede ser abierto, resuelto o en investigacion.");
        }

        return errores;
    }
}