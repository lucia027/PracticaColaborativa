using System.Collections.Generic;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Factory;

public static class SustanciaFactory {
    public static List<Sustancia> Seed() {
        var datosBase = new List<Sustancia>();

        datosBase.Add(new Medicina(
            nombre: "Antidoto Imperial contra Arsénico",
            descripcion: "Neutraliza intoxicaciones por arsenico",
            precio: 45,
            disponibilidad: Disponibilidad.Rara,
            nivelPeligro: Peligro.Bajo,
            sintoma: "Intoxicacion por arsenico",
            dosisRecomedada: 1.5,
            efectosSecundario: "Nauseas leves",
            tiempoEfecto: 30
            ));
            
        datosBase.Add(new Medicina(
            nombre: "Decoccion Antipirético Imperial",
            descripcion: "Reduce la fiebre alta",
            precio: 60,
            disponibilidad: Disponibilidad.Comun,
            nivelPeligro: Peligro.Bajo,
            sintoma: "Fiebre alta",
            dosisRecomedada: 1.5,
            efectosSecundario: "Somnolencia",
            tiempoEfecto: 45
        ));

        datosBase.Add(new Medicina(
            nombre: "Polvo Digestivo de Hierbas",
            descripcion: "Alivia dolores estomacales",
            precio: 25,
            disponibilidad: Disponibilidad.MuyRara,
            nivelPeligro: Peligro.Bajo,
            sintoma: "Dolor abdominal",
            dosisRecomedada: 1.0,
            efectosSecundario: "Gases",
            tiempoEfecto: 20
        ));

        datosBase.Add(new Medicina(
            nombre: "Elixir Anticonvulsivo del Pabellon Jade",
            descripcion: "Reduce convulsiones",
            precio: 80,
            disponibilidad: Disponibilidad.Comun,
            nivelPeligro: Peligro.Medio,
            sintoma: "Convulsiones",
            dosisRecomedada: 0.8,
            efectosSecundario: "Mareo",
            tiempoEfecto: 25
        ));

        datosBase.Add(new Medicina(
            nombre: "Infusion Detoxificante de Maomao",
            descripcion: "Neutraliza toxinas leves",
            precio: 35,
            disponibilidad: Disponibilidad.Rara,
            nivelPeligro: Peligro.Bajo,
            sintoma: "Envenenamiento leve",
            dosisRecomedada: 2.0,
            efectosSecundario: "Sudoracion",
            tiempoEfecto: 40
        ));

        datosBase.Add(new Medicina(
            nombre: "Jarabe Respiratorio Imperial",
            descripcion: "Tratamiento para la tos",
            precio: 55,
            disponibilidad: Disponibilidad.Rara,
            nivelPeligro: Peligro.Bajo,
            sintoma: "Tos",
            dosisRecomedada: 1.2,
            efectosSecundario: "Sequedad bucal",
            tiempoEfecto: 35
        ));

        datosBase.Add(new Medicina(
            nombre: "Tonico Revitalizante de Palacio",
            descripcion: "Recupera energia tras intoxicaciones",
            precio: 70,
            disponibilidad: Disponibilidad.Comun,
            nivelPeligro: Peligro.Bajo,
            sintoma: "Debilidad",
            dosisRecomedada: 1.0,
            efectosSecundario: "Insomnio leve",
            tiempoEfecto: 60
        ));

        return datosBase;
    }
}