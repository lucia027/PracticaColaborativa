using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public sealed record Medicina : Sustancia {
    public string Sintoma { get; init; } = string.Empty;
    public double DosisRecomendada { get; init; }
    public string EfectosSecundarios { get; init; } = string.Empty;
    public int TiempoEfecto { get; init; }
}