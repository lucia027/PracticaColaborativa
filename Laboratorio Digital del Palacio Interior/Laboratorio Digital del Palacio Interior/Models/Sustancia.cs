using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public abstract class Sustancia(string nombre, string descripcion, decimal precio, Disponibilidad disponibilidad, Peligro nivelPeligro) {
    public int Id { get; init; } 
    public string Nombre { get; set; } = nombre;
    public string Descripcion { get; set; } = descripcion;
    public decimal Precio { get; set; } = precio;
    public Disponibilidad Disponibilidad { get; set; } = disponibilidad;
    public Peligro NivelPeligro { get; set; } = nivelPeligro;
}