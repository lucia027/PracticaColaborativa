using System.Collections.Generic;
using System.Linq;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Factory;

public class CasosMedicosFactory {
    public static List<CasoMedico> Seed() {
        var datosBase = new List<CasoMedico>();

        var sustancias = SustanciaFactory.Seed();
        var medicinas = sustancias.OfType<Medicina>().ToList();
        var venenos = sustancias.OfType<Veneno>().ToList();
        
        datosBase.Add(new CasoMedico(
            sintomas: "Palidez extrema, debilidad general, dolores de cabeza y náuseas recurrentes en la concubina del Pabellón de Jade.",
            gravedad: Gravedad.Grave, 
            causaSospecha: CausaSospecha.Veneno, 
            sustanciasSospechosas: new HashSet<Veneno?> { 
                venenos.First(v => v.Nombre == "Arsenico Blanco Refinado") 
            },
            tratamientos: new HashSet<Medicina> { 
                medicinas.First(m => m.Nombre == "Antidoto Imperial contra Arsénico"),
                medicinas.First(m => m.Nombre == "Tonico Revitalizante de Palacio")
            },
            estado: EstadoCasoMedico.Resuelto
        ));

        datosBase.Add(new CasoMedico(
            sintomas: "Dolor abdominal agudo y mareos repentinos tras consumir la sopa fría servida por los eunucos.",
            gravedad: Gravedad.Moderada,
            causaSospecha: CausaSospecha.Enfermedad,
            sustanciasSospechosas: new HashSet<Veneno?> { 
                venenos.First(v => v.Nombre == "Polvo Gastrotoxico Irritante") 
            },
            tratamientos: new HashSet<Medicina> { 
                medicinas.First(m => m.Nombre == "Polvo Digestivo de Hierbas"),
                medicinas.First(m => m.Nombre == "Infusion Detoxificante de Maomao")
            },
            estado: EstadoCasoMedico.Abierto
        ));

        datosBase.Add(new CasoMedico(
            sintomas: "Convulsiones repentinas, alucinaciones y pérdida de conocimiento.",
            gravedad: Gravedad.Grave,
            causaSospecha: CausaSospecha.Veneno,
            sustanciasSospechosas: new HashSet<Veneno?> { 
                venenos.First(v => v.Nombre == "Extracto Neurotoxico de Hongo Negro"),
                venenos.First(v => v.Nombre == "Toxina Paralizante de Serpiente")
            },
            tratamientos: new HashSet<Medicina> { 
                medicinas.First(m => m.Nombre == "Elixir Anticonvulsivo del Pabellon Jade")
            },
            estado: EstadoCasoMedico.EnInvestigacion
        ));

        datosBase.Add(new CasoMedico(
            sintomas: "Tos seca persistente que empeora al encender los braseros aromáticos en la habitación.",
            gravedad: Gravedad.Leve,
            causaSospecha: CausaSospecha.Desconocida,
            sustanciasSospechosas: new HashSet<Veneno?> { 
                venenos.First(v => v.Nombre == "Polvo Toxico de Concubina") 
            },
            tratamientos: new HashSet<Medicina> { 
                medicinas.First(m => m.Nombre == "Jarabe Respiratorio Imperial")
            },
            estado: EstadoCasoMedico.Resuelto
        ));

        return datosBase;
    }
}