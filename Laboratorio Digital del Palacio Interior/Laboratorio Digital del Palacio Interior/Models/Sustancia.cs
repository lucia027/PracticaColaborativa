using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

/// <summary>
/// Clase base abstracta para los tipos de sustancias.
/// </summary>
public abstract record Sustancia {
    public int Id { get; init; } 
    public string Nombre { get; init; } = string.Empty;
    public string Descripcion { get; init; } = string.Empty;
    public decimal Precio { get; init; }
    public Disponibilidad Disponibilidad { get; init; }
    public Peligro NivelPeligro { get; init; }
}