using System.Globalization;
using Laboratorio_Digital_del_Palacio_Interior.Dto;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Mappers;

public static class SustanciaMapper {
    
    // Cultura invariante para evitar problemas con los numeros.
    private static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;
    
    /// <summary>
    /// Convierte las SustanciasDto a modelos.
    /// </summary>
    /// <param name="dto">SustanciaDto para convertir.</param>
    /// <returns>Sustancia pasada a modelo.</returns>
    /// <exception cref="ArgumentException">El tipo de sustancia no es el correcto.</exception>
    public static Sustancia ToModel(this SustanciaDto dto) {
        return dto.Tipo switch {
            "Medicina" => new Medicina {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = decimal.TryParse(dto.Precio, InvariantCulture, out var precio) ? precio : 0,
                Disponibilidad = Enum.TryParse(dto.Disponibilidad, out Disponibilidad disponibilidad) ? disponibilidad : Disponibilidad.Comun,
                NivelPeligro = Enum.TryParse(dto.NivelPeligro, out Peligro peligro) ? peligro : Peligro.Nulo,
                Sintoma = dto.Sintoma ?? string.Empty,
                DosisRecomendada = double.TryParse(dto.DosisRecomendada, InvariantCulture, out var dosis) ? dosis : 0,
                EfectosSecundarios = dto.EfectosSecundarios ?? string.Empty,
                TiempoEfecto = dto.TiempoEfecto ?? 0,
            },
            "Afrodisiaco" => new Afrodisiaco {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = decimal.TryParse(dto.Precio, InvariantCulture, out var precio) ? precio : 0,
                Disponibilidad = Enum.TryParse(dto.Disponibilidad, out Disponibilidad disponibilidad) ? disponibilidad : Disponibilidad.Comun,
                NivelPeligro = Enum.TryParse(dto.NivelPeligro, out Peligro peligro) ? peligro : Peligro.Nulo,
                IntensidadEfecto = dto.IntensidadEfecto ?? 0,
                Duracion = dto.Duracion ?? 0,
                ContraIndicaciones = dto.ContraIndicaciones ?? string.Empty,
                RiegosUso = dto.RiegosUso ?? string.Empty
            },
            "Veneno" => new Veneno {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = decimal.TryParse(dto.Precio, out var precio) ? precio : 0,
                Disponibilidad = Enum.TryParse(dto.Disponibilidad, out Disponibilidad disponibilidad) ? disponibilidad : Disponibilidad.Comun,
                NivelPeligro = Enum.TryParse(dto.NivelPeligro, out Peligro peligro) ? peligro : Peligro.Nulo,
                ViaDeAdministracion = Enum.TryParse(dto.ViaDeAdministracion, out ViaDeAdministracion via) ? via : ViaDeAdministracion.Contacto,
                TiempoAparicion = dto.TiempoAparicion ?? 0,
                Antidoto = dto.Antidoto.ToModel() as Medicina,
                GradoToxicidad = dto.GradoToxicidad ?? 0,
            },

            _ => throw new ArgumentException("El tipo de sustancia es desconocido.")
        };
    }

    /// <summary>
    /// Convierte las sustancias a SustanciasDto.
    /// </summary>
    /// <param name="sustancia">Sustancia para convertir.</param>
    /// <returns>SustanciaDto.</returns>
    /// <exception cref="ArgumentException">El tipo de sustancia es desconocido.</exception>
    public static SustanciaDto ToDto(this Sustancia sustancia) {
        return sustancia switch {
            Medicina medicina => new SustanciaDto(
                medicina.Id,
                medicina.Nombre,
                medicina.Descripcion,
                medicina.Precio.ToString(InvariantCulture),
                medicina.Disponibilidad.ToString(),
                medicina.NivelPeligro.ToString(),
                "Medicina",
                medicina.Sintoma,
                medicina.DosisRecomendada.ToString(InvariantCulture),
                medicina.EfectosSecundarios,
                medicina.TiempoEfecto,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            ),
            Afrodisiaco afrodisiaco => new SustanciaDto(
                afrodisiaco.Id,
                afrodisiaco.Nombre,
                afrodisiaco.Descripcion,
                afrodisiaco.Precio.ToString(InvariantCulture),
                afrodisiaco.Disponibilidad.ToString(),
                afrodisiaco.NivelPeligro.ToString(),
                "Afrodisiaco",
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                afrodisiaco.IntensidadEfecto,
                afrodisiaco.Duracion,
                afrodisiaco.ContraIndicaciones,
                afrodisiaco.RiegosUso
            ),
            Veneno veneno => new SustanciaDto(
                veneno.Id,
                veneno.Nombre,
                veneno.Descripcion,
                veneno.Precio.ToString(InvariantCulture),
                veneno.Disponibilidad.ToString(),
                veneno.NivelPeligro.ToString(),
                "Veneno",
                null,
                null,
                null,
                null,
                veneno.ViaDeAdministracion.ToString(),
                veneno.TiempoAparicion,
                veneno.Antidoto.ToDto(),
                veneno.GradoToxicidad,
                veneno.ProbabilidadSupervivencia,
                null,
                null,
                null,
                null
            ),

            _ => throw new ArgumentException("El tipo de sustancia es desconocido.")
        };
    }
}