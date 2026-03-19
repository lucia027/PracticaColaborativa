using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

/// <summary>
/// Representa las medicinas en el sistema.
/// </summary>
public sealed record Medicina : Sustancia {
    public string Sintoma { get; init; } = string.Empty;
    public double DosisRecomendada { get; init; }
    public string EfectosSecundarios { get; init; } = string.Empty;
    public int TiempoEfecto { get; init; }

    public override string ToString() {
        return $"Medicina => Id: {Id}, Nombre: {Nombre}, Descripcion: {Descripcion}, Precio {Precio}, Disponibilidad: {Disponibilidad}, Nivel de peligro: {NivelPeligro}, Sintoma: {Sintoma}, Dosis recomendada: {DosisRecomendada}, Efectos secundarios: {EfectosSecundarios}, Tiempo de efecto en minutos: {TiempoEfecto}.";
    }
}