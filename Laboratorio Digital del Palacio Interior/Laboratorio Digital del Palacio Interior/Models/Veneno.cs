using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public sealed class Veneno(string nombre, string descripcion, decimal precio, Disponibilidad disponibilidad, Peligro nivelPeligro, ViaDeAdministracion viaDeAdministracion, int tiempoAparicion, Medicina antidoto, int gradoToxicidad) : Sustancia(nombre, descripcion, precio, disponibilidad, nivelPeligro) {
    public ViaDeAdministracion ViaDeAdministracion { get; set; } = viaDeAdministracion;
    public int TiempoAparicion { get; set; } = tiempoAparicion;
    public Medicina Antidoto { get; set; } = antidoto;
    public int GradoToxicidad { get; set; } = gradoToxicidad;
    public int ProbabilidadSupervivencia => (GradoToxicidad >= 8) ? 20 : 60;
}