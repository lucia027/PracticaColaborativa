namespace El_registro_de_Jinshi.Models;

public class Noble : Personaje {
    public Rango Rango { get; set; }

    public Noble(string nombre, int edad, string rol, Rango rango) : base(nombre, edad, rol) {
        Id = GetId.GetNewId();
        Nombre = nombre;
        Edad = edad;
        Rol = rol;
        Rango = rango;
    }

    public override void RealizarTarea() {
        Console.WriteLine("Trabajando como noble..👘");
    }
}