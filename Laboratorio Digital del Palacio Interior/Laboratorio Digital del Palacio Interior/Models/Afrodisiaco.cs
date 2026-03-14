using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public sealed record Afrodisiaco: Sustancia {
    public int IntensidadEfecto { get; init; }
    public int Duracion { get; init; }
    public string ContraIndicaciones { get; init; } = string.Empty;
    public string RiegosUso { get; init; } = string.Empty;
}