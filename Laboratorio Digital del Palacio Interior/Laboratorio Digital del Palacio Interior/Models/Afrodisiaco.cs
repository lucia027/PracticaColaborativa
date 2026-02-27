using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public sealed class Afrodisiaco(string nombre, string descripcion, decimal precio, Disponibilidad disponibilidad, Peligro nivelPeligro, int intensidadEfecto, int duracion, string contraIndicaciones, string riesgoUso) : Sustancia(nombre, descripcion, precio, disponibilidad, nivelPeligro) {
    public int IntensidadEfecto { get; set; } = intensidadEfecto;
    public int Duracion { get; set; } = duracion;
    public string ContraIndicaciones { get; set; } = contraIndicaciones;
    public string RiegosUso { get; set; } = riesgoUso;
}