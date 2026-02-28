namespace El_registro_de_Jinshi.Models;

public class Sirvienta : Personaje {
    public Nivel Nivel { get; set; }

    public Sirvienta(string nombre, int edad, string rol, Nivel nivel) : base(nombre, edad, rol) {
        Id = GetId.GetNewId();
        Nombre = nombre;
        Edad = edad;
        Rol = rol;
        Nivel = nivel;
    }

    public override void RealizarTarea() {
        Console.WriteLine("Trabajando como sirvienta..🫧");
    }
}