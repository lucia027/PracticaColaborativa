using System.Collections.Generic;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Factory;

public static class SustanciaFactory {
    public static List<Sustancia> Seed() {
        var datosBase = new List<Sustancia>();

        datosBase.Add(new Medicina {
            Nombre = "Antidoto Imperial contra Arsénico",
            Descripcion = "Neutraliza intoxicaciones por arsenico",
            Precio = 45,
            Disponibilidad = Disponibilidad.Rara,
            NivelPeligro = Peligro.Bajo,
            Sintoma = "Intoxicacion por arsenico",
            DosisRecomendada = 1.5,
            EfectosSecundarios = "Nauseas leves",
            TiempoEfecto = 30
            });
            
        datosBase.Add(new Medicina{
            Nombre = "Decoccion Antipirético Imperial",
            Descripcion = "Reduce la fiebre alta",
            Precio = 60,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Bajo,
            Sintoma = "Fiebre alta",
            DosisRecomendada =  1.5,
            EfectosSecundarios ="Somnolencia",
            TiempoEfecto = 45
        });

        datosBase.Add(new Medicina { 
            Nombre = "Polvo Digestivo de Hierbas",
            Descripcion = "Alivia dolores estomacales",
            Precio = 25,
            Disponibilidad = Disponibilidad.MuyRara,
            NivelPeligro = Peligro.Bajo,
            Sintoma =  "Dolor abdominal",
            DosisRecomendada = 1.0,
            EfectosSecundarios ="Gases",
            TiempoEfecto = 20
        });

        datosBase.Add(new Medicina{
            Nombre = "Elixir Anticonvulsivo del Pabellon Jade",
            Descripcion = "Reduce convulsiones",
            Precio = 80,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Medio,
            Sintoma = "Convulsiones",
            DosisRecomendada = 0.8,
            EfectosSecundarios = "Mareo",
            TiempoEfecto = 25
        });

        datosBase.Add(new Medicina{
            Nombre = "Infusion Detoxificante de Maomao",
            Descripcion = "Neutraliza toxinas leves",
            Precio = 35,
            Disponibilidad = Disponibilidad.Rara,
            NivelPeligro = Peligro.Bajo,
            Sintoma = "Envenenamiento leve",
            DosisRecomendada = 2.0,
            EfectosSecundarios = "Sudoracion",
            TiempoEfecto = 40
        });

        datosBase.Add(new Medicina{
            Nombre = "Jarabe Respiratorio Imperial",
            Descripcion = "Tratamiento para la tos",
            Precio = 55,
            Disponibilidad =  Disponibilidad.Rara,
            NivelPeligro = Peligro.Bajo,
            Sintoma = "Tos",
            DosisRecomendada = 1.2,
            EfectosSecundarios = "Sequedad bucal",
            TiempoEfecto = 35
        });

        datosBase.Add(new Medicina{
            Nombre = "Tonico Revitalizante de Palacio",
            Descripcion = "Recupera energia tras intoxicaciones",
            Precio = 70,
            Disponibilidad =  Disponibilidad.Comun,
            NivelPeligro =  Peligro.Bajo,
            Sintoma = "Debilidad",
            DosisRecomendada = 1.0,
            EfectosSecundarios = "Insomnio leve",
            TiempoEfecto =  60
        });

        return datosBase;
    }
}