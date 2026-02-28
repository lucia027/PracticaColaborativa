namespace El_registro_de_Jinshi.Models;

public abstract class Personaje {
    public int Id { get; init; }
    public string Nombre { get; init; }
    public int Edad { get; set; }
    public string Rol { get; set; }

    public Personaje(string nombre, int edad, string rol) {
        Id = GetId.GetNewId();
        Nombre = nombre;
        Edad = edad;
        Rol = rol;
    }

    public abstract void RealizarTarea();
}