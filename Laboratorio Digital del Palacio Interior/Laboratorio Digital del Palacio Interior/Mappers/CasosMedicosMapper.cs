using System.Globalization;
using Laboratorio_Digital_del_Palacio_Interior.Dto;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Mappers;

public static class CasosMedicosMapper {

    // Formato ISO para las fechas.
    private const string IsoFormat = "s";
    
    // Cultura invariante para evitar problemas con los numeros.
    private static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;
    
    /// <summary>
    /// Convierte los CasosMedicosDto a modelos.
    /// </summary>
    /// <param name="dto">CasoMedicoDto para convertir.</param>
    /// <returns>Caso medico pasado a modelo.</returns>
    public static CasoMedico ToModel(this CasosMedicosDto dto) {
        return new CasoMedico {
            Id = dto.Id,
            CausaSospecha = Enum.TryParse(dto.CausaSospecha, out CausaSospecha causa) ? causa : CausaSospecha.Desconocida,
            Estado = Enum.TryParse(dto.Estado, out EstadoCasoMedico estado) ? estado : EstadoCasoMedico.Abierto,
            FechaInicio = DateTime.Parse(dto.FechaInicio, InvariantCulture),
            Gravedad = Enum.TryParse(dto.Gravedad, out Gravedad gravedad) ? gravedad : Gravedad.Nulo,
            Sintomas = dto.Sintomas,
            SustanciasSospechosas = dto.SustanciasSospechosas?.Select( s => s.ToModel()) as HashSet<Veneno>,
            Tratamientos = dto.Tratamientos?.Select( s => s.ToModel()) as HashSet<Medicina>
        };
    }

    /// <summary>
    /// Convierte los casos medicos a CasosMedicosDto.
    /// </summary>
    /// <param name="casoMedico">Caso medico para convertir.</param>
    /// <returns>CasoMedicoDto.</returns>
    public static CasosMedicosDto ToDto(this CasoMedico casoMedico) {
        return new CasosMedicosDto(
            casoMedico.Id,
            casoMedico.Sintomas,
            casoMedico.FechaInicio.ToString(IsoFormat, InvariantCulture),
            casoMedico.Gravedad.ToString(),
            casoMedico.CausaSospecha.ToString(),
            casoMedico.SustanciasSospechosas?.Select(v => v.ToDto()).ToHashSet(),
            casoMedico.Tratamientos?.Select(m => m.ToDto()).ToHashSet(),
            casoMedico.Estado.ToString()
        );
    }
}