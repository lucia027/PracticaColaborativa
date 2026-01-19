namespace Currantes.Models;

public abstract class Trabajador : ICalcularSalario {
    private string Nombre { get; set; }
    private string Apellidos { get; set; }
}