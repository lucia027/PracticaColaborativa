using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

/// <summary>
/// Representa los venenos en el sistema.
/// </summary>
public sealed record Veneno : Sustancia {
    public ViaDeAdministracion ViaDeAdministracion { get; init; }
    public int TiempoAparicion { get; init; }
    public required Medicina Antidoto { get; init; }
    public int GradoToxicidad { get; init; }
    public int ProbabilidadSupervivencia => (GradoToxicidad >= 8) ? 20 : 60;
    
    public override string ToString() {
        return $"Medicina => Id: {Id}, Nombre: {Nombre}, Descripcion: {Descripcion}, Precio {Precio}, Disponibilidad: {Disponibilidad}, Nivel de peligro: {NivelPeligro}, Via de administración: {ViaDeAdministracion}, Tiempo de aparicion: {TiempoAparicion}, Antidoto: {Antidoto}, Grado de toxicidad: {GradoToxicidad}, Probabilidad de supervivencia: {ProbabilidadSupervivencia}.";
    }
}