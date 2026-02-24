using System.ComponentModel.Design;

namespace Simulacion_de_una_empresa_de_heroes.Models;

public abstract class Heroe {
    public int Id { get; init; }
    public string Nombre { get; set; }
    public int Nivel { get; set; }
    public int Energia { get; set; }
    public int Experiencia { get; set; }
    public int PoderBase { get; set; }

    
    public void CalcularPoderTotal() {
        var poderTotal = PoderBase + (Experiencia * Nivel);
        Console.WriteLine($"El poder total es {poderTotal}");
    }

    public abstract void Entrenar();

    public abstract void Descansar();
}