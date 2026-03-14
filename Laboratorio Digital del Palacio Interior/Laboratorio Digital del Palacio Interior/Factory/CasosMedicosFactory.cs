using System.Collections.Generic;
using System.Linq;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Factory;

/// <summary>
///  Clase encargada de generar los datos base de los casos médicos.
/// </summary>
public class CasosMedicosFactory {
    /// <summary>
    /// Genera los datos base de los casos médicos.
    /// </summary>
    /// <returns>Lista de casos medicos</returns>
    public static List<CasoMedico> Seed() {
        var datosBase = new List<CasoMedico>();
        
        datosBase.Add(new CasoMedico{
            Sintomas = "Palidez extrema, debilidad general, dolores de cabeza y náuseas recurrentes en la concubina del Pabellón de Jade.",
            Gravedad = Gravedad.Grave, 
            CausaSospecha = CausaSospecha.Veneno, 
            SustanciasSospechosas = null,
            Tratamientos = null,
            Estado = EstadoCasoMedico.Resuelto
        });

        datosBase.Add(new CasoMedico{
            Sintomas = "Dolor abdominal agudo y mareos repentinos tras consumir la sopa fría servida por los eunucos.",
            Gravedad = Gravedad.Moderada,
            CausaSospecha = CausaSospecha.Enfermedad,
            SustanciasSospechosas = null,
            Tratamientos = null,
            Estado = EstadoCasoMedico.Abierto
        });

        datosBase.Add(new CasoMedico{
            Sintomas = "Convulsiones repentinas, alucinaciones y pérdida de conocimiento.",
            Gravedad = Gravedad.Grave,
            CausaSospecha = CausaSospecha.Veneno,
            SustanciasSospechosas = null,
            Tratamientos = null,
            Estado = EstadoCasoMedico.EnInvestigacion
        });

        datosBase.Add(new CasoMedico{
            Sintomas = "Tos seca persistente que empeora al encender los braseros aromáticos en la habitación.",
            Gravedad = Gravedad.Leve,
            CausaSospecha = CausaSospecha.Desconocida,
            SustanciasSospechosas = null,
            Tratamientos = null,
            Estado = EstadoCasoMedico.Resuelto
        });

        return datosBase;
    }
}