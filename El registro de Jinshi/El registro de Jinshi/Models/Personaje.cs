namespace El_registro_de_Jinshi.Models;

public abstract class Personaje {
    protected int Id { get; init; }
    protected string Nombre { get; init; } = string.Empty;
    protected int Edad { get; set; }
    protected string Rol { get; set; } = string.Empty;

    public Personaje(string nombre, int edad, string rol) {
        Id = GetId.GetNewId();
        Nombre = nombre;
        Edad = edad;
        Rol = rol;
    }

    public abstract void RealizarTarea();
}