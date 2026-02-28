namespace Simulacion_de_una_empresa_de_heroes.Models;

public class Guerrero : Heroe {
    public int Fuerza { get; set; }

    public override void Entrenar() {
        if (Energia > 0) {
            Fuerza += 10 + (Nivel / 2);
            Energia -= 5;
            Experiencia+= 5;
        } else {
            Console.WriteLine("No puedes entrenar necesitas descansar.");
        } 
        Energia = (Energia < 0) ? Energia = 0 : Energia = Energia;
    }

    public override void Descansar() {
        Energia += 10;
    }
}