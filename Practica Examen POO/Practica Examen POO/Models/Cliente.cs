namespace Practica_Examen_POO.Models;

public class Cliente(string dni, string nombre, string direccion) {
    internal string Dni { get; init; } = dni;
    internal string Nombre { get; init; } = nombre;
    internal string Direccion { get; set; } = direccion;


    public override string ToString() {
        return $"Cliente =>  Dni: {Dni}, Nombre: {Nombre}, Dirección: {Direccion}.";
    }
}