namespace El_registro_de_Jinshi.Models;

public class Boticaria : Personaje{
    public Especialidad Especialidad { get; set; }

    public Boticaria(string nombre, int edad, string rol, Especialidad especialidad) : base(nombre, edad, rol) {
        Id = GetId.GetNewId();
        Nombre = nombre;
        Edad = edad;
        Rol = rol;
        Especialidad = especialidad;
    }

    public override void RealizarTarea() {
        Console.WriteLine("Trabajando como boticaria..🌿");
    }
}