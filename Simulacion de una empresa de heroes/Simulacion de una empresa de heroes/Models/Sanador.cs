namespace Simulacion_de_una_empresa_de_heroes.Models;

public class Sanador : Heroe {
    public int CapacidadCuracion { get; set; }


    public override void Entrenar() {
        if (Energia > 0) {
            CapacidadCuracion += 5 * (Experiencia);
            Experiencia += 5;
            Energia -= 5;
        } else {
            Console.WriteLine("No puedes entrenar,necesitas descansar.");
        }
        Energia = (Energia < 0) ? Energia = 0 : Energia = Energia;
    }

    public override void Descansar() {
        Energia += 10;
    }
}