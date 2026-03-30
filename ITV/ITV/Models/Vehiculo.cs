using ITV.Enums;

namespace ITV.Models;

/// <summary>
/// Representa a un vehiculo en el sistema.
/// </summary>
public class Vehiculo {
    public int Id { get; init; }
    public string Matricula { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Cilindrada { get; set; }
    public Motor Motor { get; set; }
    public string DniDueño { get; set; } = string.Empty;
}