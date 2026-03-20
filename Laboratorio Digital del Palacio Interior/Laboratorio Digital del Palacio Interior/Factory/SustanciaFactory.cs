using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Factory;

/// <summary>
///  Clase encargada de generar los datos base de las sustancias.
/// </summary>
public static class SustanciaFactory {
    /// <summary>
    /// Genera los datos base de las sustancias.
    /// </summary>
    /// <returns>Lista de sustancias.</returns>
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

        datosBase.Add(new Medicina {
            Nombre = "Decoccion Antipirético Imperial",
            Descripcion = "Reduce la fiebre alta",
            Precio = 60,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Bajo,
            Sintoma = "Fiebre alta",
            DosisRecomendada = 1.5,
            EfectosSecundarios = "Somnolencia",
            TiempoEfecto = 45
        });

        datosBase.Add(new Medicina {
            Nombre = "Polvo Digestivo de Hierbas",
            Descripcion = "Alivia dolores estomacales",
            Precio = 25,
            Disponibilidad = Disponibilidad.MuyRara,
            NivelPeligro = Peligro.Bajo,
            Sintoma = "Dolor abdominal",
            DosisRecomendada = 1.0,
            EfectosSecundarios = "Gases",
            TiempoEfecto = 20
        });

        datosBase.Add(new Medicina {
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

        datosBase.Add(new Medicina {
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

        datosBase.Add(new Medicina {
            Nombre = "Jarabe Respiratorio Imperial",
            Descripcion = "Tratamiento para la tos",
            Precio = 55,
            Disponibilidad = Disponibilidad.Rara,
            NivelPeligro = Peligro.Bajo,
            Sintoma = "Tos",
            DosisRecomendada = 1.2,
            EfectosSecundarios = "Sequedad bucal",
            TiempoEfecto = 35
        });

        datosBase.Add(new Medicina {
            Nombre = "Tonico Revitalizante de Palacio",
            Descripcion = "Recupera energia tras intoxicaciones",
            Precio = 70,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Bajo,
            Sintoma = "Debilidad",
            DosisRecomendada = 1.0,
            EfectosSecundarios = "Insomnio leve",
            TiempoEfecto = 60
        });

        datosBase.Add(new Veneno {
            Nombre = "Polvo de Nieve Fría",
            Descripcion = "Un veneno silencioso usado en la corte. Produce escalofríos y debilidad progresiva.",
            Precio = 120,
            Disponibilidad = Disponibilidad.Rara,
            NivelPeligro = Peligro.Alto,
            ViaDeAdministracion = ViaDeAdministracion.Contacto,
            TiempoAparicion = 45,
            Antidoto = datosBase
                .OfType<Medicina>()
                .First(m => m.Nombre == "Antidoto Imperial contra Arsénico"),
            GradoToxicidad = 8
        });

        datosBase.Add(new Veneno {
            Nombre = "Lágrimas de la Flor Fantasma",
            Descripcion = "Extracto de una flor venenosa que causa desorientación y pérdida de fuerza.",
            Precio = 95,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Medio,
            ViaDeAdministracion = ViaDeAdministracion.Oral,
            TiempoAparicion = 20,
            Antidoto = datosBase
                .OfType<Medicina>()
                .First(m => m.Nombre == "Decoccion Antipirético Imperial"),
            GradoToxicidad = 6
        });

        datosBase.Add(new Veneno {
            Nombre = "Aguja de Serpiente Carmesí",
            Descripcion = "Veneno derivado de un reptil exótico. Provoca entumecimiento y fiebre.",
            Precio = 180,
            Disponibilidad = Disponibilidad.MuyRara,
            NivelPeligro = Peligro.Alto,
            ViaDeAdministracion = ViaDeAdministracion.Contacto,
            TiempoAparicion = 10,
            Antidoto = datosBase
                .OfType<Medicina>()
                .First(m => m.Nombre == "Polvo Digestivo de Hierbas"),
            GradoToxicidad = 9
        });

        datosBase.Add(new Veneno {
            Nombre = "Polvo de Jade Marchito",
            Descripcion = "Sustancia usada en intrigas palaciegas. Causa debilidad muscular y mareos.",
            Precio = 70,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Medio,
            ViaDeAdministracion = ViaDeAdministracion.Inhalacion,
            TiempoAparicion = 30,
            Antidoto = datosBase
                .OfType<Medicina>()
                .First(m => m.Nombre == "Elixir Anticonvulsivo del Pabellon Jade"),
            GradoToxicidad = 5
        });

        datosBase.Add(new Veneno {
            Nombre = "Néctar de la Noche",
            Descripcion = "Un veneno líquido oscuro que provoca somnolencia profunda.",
            Precio = 150,
            Disponibilidad = Disponibilidad.Rara,
            NivelPeligro = Peligro.Alto,
            ViaDeAdministracion = ViaDeAdministracion.Oral,
            TiempoAparicion = 15,
            Antidoto = datosBase
                .OfType<Medicina>()
                .First(m => m.Nombre == "Infusion Detoxificante de Maomao"),
            GradoToxicidad = 7
        });

        datosBase.Add(new Veneno {
            Nombre = "Humo de la Luna Roja",
            Descripcion = "Sustancia quemada para liberar vapores que causan confusión.",
            Precio = 110,
            Disponibilidad = Disponibilidad.Rara,
            NivelPeligro = Peligro.Medio,
            ViaDeAdministracion = ViaDeAdministracion.Inhalacion,
            TiempoAparicion = 5,
            Antidoto = datosBase
                .OfType<Medicina>()
                .First(m => m.Nombre == "Jarabe Respiratorio Imperial"),
            GradoToxicidad = 6
        });

        datosBase.Add(new Afrodisiaco {
            Nombre = "Perfume de la Flor Carmesí",
            Descripcion = "Aroma dulce que estimula el ánimo y la cercanía emocional.",
            Precio = 60,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Bajo,
            IntensidadEfecto = 4,
            Duracion = 120,
            ContraIndicaciones = "Evitar en personas con alergias fuertes.",
            RiegosUso = "Ligero enrojecimiento facial."
        });

        datosBase.Add(new Afrodisiaco {
            Nombre = "Elixir de la Luna Plateada",
            Descripcion = "Bebida suave que aumenta la calidez corporal y la sensibilidad.",
            Precio = 85,
            Disponibilidad = Disponibilidad.Rara,
            NivelPeligro = Peligro.Bajo,
            IntensidadEfecto = 6,
            Duracion = 90,
            ContraIndicaciones = "No mezclar con alcohol.",
            RiegosUso = "Somnolencia leve."
        });

        datosBase.Add(new Afrodisiaco {
            Nombre = "Polvo de Flor de Durazno",
            Descripcion = "Sustancia aromática usada en rituales románticos.",
            Precio = 40,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Bajo,
            IntensidadEfecto = 3,
            Duracion = 60,
            ContraIndicaciones = "Evitar en embarazadas.",
            RiegosUso = "Picor nasal ocasional."
        });

        datosBase.Add(new Afrodisiaco {
            Nombre = "Té de Pétalos Rosados",
            Descripcion = "Infusión suave que relaja y mejora el estado de ánimo.",
            Precio = 30,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Bajo,
            IntensidadEfecto = 2,
            Duracion = 45,
            ContraIndicaciones = "No recomendado para hipertensos.",
            RiegosUso = "Ligera aceleración del pulso."
        });

        datosBase.Add(new Afrodisiaco {
            Nombre = "Esencia de Orquídea Dorada",
            Descripcion = "Extracto aromático muy apreciado en la nobleza.",
            Precio = 120,
            Disponibilidad = Disponibilidad.MuyRara,
            NivelPeligro = Peligro.Medio,
            IntensidadEfecto = 7,
            Duracion = 150,
            ContraIndicaciones = "Evitar en personas con problemas cardíacos.",
            RiegosUso = "Aumento temporal de la temperatura corporal."
        });

        datosBase.Add(new Afrodisiaco {
            Nombre = "Néctar de Melocotón Dulce",
            Descripcion = "Jarabe suave que genera sensación de bienestar.",
            Precio = 55,
            Disponibilidad = Disponibilidad.Comun,
            NivelPeligro = Peligro.Bajo,
            IntensidadEfecto = 5,
            Duracion = 80,
            ContraIndicaciones = "No apto para diabéticos.",
            RiegosUso = "Ligera somnolencia."
        });

        return datosBase;
    }
}