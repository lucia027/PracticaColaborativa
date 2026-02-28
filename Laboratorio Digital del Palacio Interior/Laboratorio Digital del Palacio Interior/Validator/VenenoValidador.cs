using System;
using System.Collections.Generic;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;
using Laboratorio_Digital_del_Palacio_Interior.Validator.Common;

namespace Laboratorio_Digital_del_Palacio_Interior.Validator;

public class VenenoValidador : IValidator<Sustancia> {
    public IEnumerable<string> Validar(Sustancia entity) {
        var errores = new List<string>();

        if (entity is not Veneno veneno) {
            errores.Add("ERROR - La sustancia no es un veneno.");
            return errores;
        }
        
        if (string.IsNullOrEmpty(veneno.Nombre)) {
            errores.Add("ERROR - El nombre no puede ser nulo o estar vacio.");
        }

        if (string.IsNullOrEmpty(veneno.Descripcion)) {
            errores.Add("ERROR - La descripción no puede ser nulo o estar vacia.");
        }
        
        if (veneno.Precio < 0) {
            errores.Add("ERROR - El precio no puede ser negativo.");
        }
        
        if (veneno.Disponibilidad < 0) {
            errores.Add("ERROR - La disponibilidad no puede ser negativa.");
        }

        if (!Enum.IsDefined(typeof(Peligro), veneno.NivelPeligro)) {
            errores.Add("ERROR - El peligro no puede ser diferente de nulo, bajo, medio o alto.");
        }
        
        if (!Enum.IsDefined(typeof(ViaDeAdministracion), veneno.ViaDeAdministracion)) {
            errores.Add("ERROR - La vida de administracion no puede ser diferente de oral, contactos o inhalación.");
        }
        
        if (veneno.TiempoAparicion < 0) {
            errores.Add("ERROR - El tiempo de aparicion de los sintomas no puede ser negativo.");
        }
        
        if (veneno.Antidoto is not Medicina) {
            errores.Add("ERROR - El antidoto solo puede ser una medicina.");
        }

        if (veneno.GradoToxicidad < 0) {
            errores.Add("ERROR - El grado de toxicidad no puede ser negativo.");
        }

        return errores;
    }
}