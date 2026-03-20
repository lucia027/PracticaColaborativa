namespace Laboratorio_Digital_del_Palacio_Interior.Dto;

public record SustanciaDto(
    int Id,
    string Nombre,
    string Descripcion,
    string Precio,
    string Disponibilidad,
    string NivelPeligro,
    string Tipo,
    string? Sintoma,
    string? DosisRecomendada,
    string? EfectosSecundarios,
    int? TiempoEfecto,
    string? ViaDeAdministracion,
    int? TiempoAparicion,
    SustanciaDto? Antidoto,
    int? GradoToxicidad,
    int? ProbabilidadSupervivencia,
    int? IntensidadEfecto,
    int? Duracion,
    string? ContraIndicaciones,
    string? RiegosUso
) { }