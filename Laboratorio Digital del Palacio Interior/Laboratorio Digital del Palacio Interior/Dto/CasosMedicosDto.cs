namespace Laboratorio_Digital_del_Palacio_Interior.Dto;

public record CasosMedicosDto(
    int Id,
    string Sintomas,
    string FechaInicio,
    string Gravedad,
    string CausaSospecha,
    string? SustanciasSospechosas,
    string? Tratamientos,
    string Estado
) { }