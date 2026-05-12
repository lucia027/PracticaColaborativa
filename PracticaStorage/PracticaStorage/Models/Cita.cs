using PracticaStorage.Enums;

namespace Itv.Models;

/// <summary>
/// Representa a un cita en el sistema.
/// </summary>
public record Cita {
    public int Id { get; init; }
    public string Matricula { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty; 
    public int Cilindrada { get; set; }
    public Motor Motor { get; set; }
    public string DniDueño { get; set; } = string.Empty;
    public DateTime FechaMatriculacion { get; set; }
    public DateTime FechaInspeccion { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public bool IsDelete { get; set; }

    public override string ToString() {
        var updateAt = UpdateAt.ToString() ?? "No se ha actualizado";
        return $"Cita: [Id-{Id}, Matricula-{Matricula}, Marca-{Marca}, Modelo-{Modelo}, Cilindrada-{Cilindrada}, Motor-{Motor.ToString()}, Dni dueño-{DniDueño}, Fecha matriculacion-{FechaMatriculacion}, Fecha inspeccion-{FechaInspeccion}, Hora de creacion-{CreateAt}, Hora de modificacion-{updateAt}, Ha sido eliminado-{IsDelete}]";
    }
}