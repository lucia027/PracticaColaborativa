using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

/// <summary>
/// Representa los afrodisiacos en el sistema.
/// </summary>
public sealed record Afrodisiaco: Sustancia {
    public int IntensidadEfecto { get; init; }
    public int Duracion { get; init; }
    public string ContraIndicaciones { get; init; } = string.Empty;
    public string RiegosUso { get; init; } = string.Empty;
    
    public override string ToString() {
        return $"Medicina => Id: {Id}, Nombre: {Nombre}, Descripcion: {Descripcion}, Precio {Precio}, Disponibilidad: {Disponibilidad}, Nivel de peligro: {NivelPeligro}, Intensidad del efecto: {IntensidadEfecto}, Duración: {Duracion}, Contraindicaciones: {ContraIndicaciones}, Riesgos de su uso: {RiegosUso}.";
    }
}