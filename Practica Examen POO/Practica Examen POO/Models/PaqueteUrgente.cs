namespace Practica_Examen_POO.Models;

public class PaqueteUrgente : Paquete {
    public double CosteSeguro { get; set; }
    
    public PaqueteUrgente(double peso, string codigoBarras, Cliente destinatario, double costeSeguro) : base(peso, codigoBarras, destinatario) {
        Id = GetId.GetNewId();
        CosteSeguro = costeSeguro;
    }

    public override double CalcularPrecioEnvio() {
        return (Peso * 4) + CosteSeguro;
    }

    public override string ToString() {
        return $"Paquete urgente =>  Id: {Id}, Peso: {Peso}, Codigo de barras: {CodigoBarras}, Coste de seguro: {CosteSeguro}, Cliente: (Dni: {Destinatario.Dni}, Nombre: {Destinatario.Nombre}, Dirección: {Destinatario.Direccion})";
    }
}