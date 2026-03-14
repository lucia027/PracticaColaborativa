using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

/// <summary>
/// Representa los venenos en el sistema.
/// </summary>
public sealed record Veneno : Sustancia {
    public ViaDeAdministracion ViaDeAdministracion { get; init; }
    public int TiempoAparicion { get; init; }
    public Medicina Antidoto { get; init; }
    public int GradoToxicidad { get; init; }
    public int ProbabilidadSupervivencia => (GradoToxicidad >= 8) ? 20 : 60;
}