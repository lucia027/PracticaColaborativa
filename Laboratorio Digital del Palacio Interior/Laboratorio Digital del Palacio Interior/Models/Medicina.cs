using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public sealed class Medicina(string nombre, string descripcion, decimal precio, Disponibilidad disponibilidad, Peligro nivelPeligro, string sintoma, double dosisRecomedada, string efectosSecundario, int tiempoEfecto) : Sustancia(nombre, descripcion, precio, disponibilidad, nivelPeligro) {
    public string Sintoma { get; set; } = sintoma;
    public double DosisRecomendada { get; set; } = dosisRecomedada;
    public string EfectosSecundarios { get; set; } = efectosSecundario;
    public int TiempoEfecto { get; set; } = tiempoEfecto;
}