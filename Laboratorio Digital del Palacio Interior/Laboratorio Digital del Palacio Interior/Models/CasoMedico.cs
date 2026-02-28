using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public class CasoMedico(string sintomas, Gravedad gravedad, CausaSospecha causaSospecha, HashSet<Veneno?> sustanciasSospechosas, HashSet<Medicina> tratamientos, EstadoCasoMedico estado) {
    public int Id { get; init; }
    public string Sintomas { get; set; } = sintomas;
    public DateTime FechaInicio { get; init; } = DateTime.Now;
    public Gravedad Gravedad { get; set; } = gravedad;
    public CausaSospecha CausaSospecha { get; set; } = causaSospecha;
    public HashSet<Veneno?> SustanciasSospechosas { get; set; } = sustanciasSospechosas;
    public HashSet<Medicina> Tratamientos { get; set; } = tratamientos;
    public EstadoCasoMedico Estado { get; set; } = estado;
}