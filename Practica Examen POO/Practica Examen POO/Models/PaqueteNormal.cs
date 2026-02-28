namespace Practica_Examen_POO.Models;

public class PaqueteNormal : Paquete {
    public PaqueteNormal(double peso, string codigoBarras, Cliente destinatario) : base(peso, codigoBarras, destinatario) {
        Id = GetId.GetNewId();
    }

    public override double CalcularPrecioEnvio() {
        return Peso * 1.5;
    }

    public override string ToString() {
        return $"Paquete Normal =>  Id: {Id}, Peso: {Peso}, Codigo e barras: {CodigoBarras}, Cliente: (Dni: {Destinatario.Dni}, Nombre: {Destinatario.Nombre}, Dirección: {Destinatario.Direccion}).";
    }
}