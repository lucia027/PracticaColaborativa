namespace Implementacion_Diagrama_EquipoFutbol.Models;

public class Persona(int Id, string Nombre, int Edad, Rol Rol) {
    public int Id { get; init; }
    private string Nombre { get; }
    private int Edad { get; set; }
    public  Rol Rol { get; set; }
}