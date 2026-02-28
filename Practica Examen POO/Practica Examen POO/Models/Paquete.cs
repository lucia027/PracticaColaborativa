namespace Practica_Examen_POO.Models;

public abstract class Paquete : IPlegable {
    protected int Id { get; init; }
    public double Peso { get; set; }
    public string CodigoBarras { get; }
    public Cliente Destinatario { get; set; }

    protected Paquete(double peso, string codigoBarras, Cliente destinatario) {
        Id = GetId.GetNewId();
        Peso = peso;
        CodigoBarras = codigoBarras;
        Destinatario = destinatario;
    }

    public override string ToString() {
        return $"Paquete =>  Id: {Id}, Peso: {Peso}, CodigoBarras: {CodigoBarras}, Cliente: (Dni: {Destinatario.Dni}, Nombre: {Destinatario.Nombre}, Direccion: {Destinatario.Direccion})";
    }

    public override bool Equals(object? obj) {
        if(obj is Paquete otroPaquete) {
            return CodigoBarras == otroPaquete.CodigoBarras;
        }
        return false;
    }

    public override int GetHashCode() {
        return HashCode.Combine(CodigoBarras);
    }

    public abstract double CalcularPrecioEnvio();
}