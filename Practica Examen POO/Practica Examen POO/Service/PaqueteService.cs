using Practica_Examen_POO.Models;
using Practica_Examen_POO.Validator;

namespace Practica_Examen_POO.Service;

public class PaqueteService(
    PaqueteUrgenteValidator paqueteUrgenteValidator, 
    PaqueteNormalValidator paqueteNormalValidator){

    void AltaReparto(Paquete?[] lista, Paquete paquete) {
        if (RevisarValidacion(paquete) == null) {
            Console.WriteLine("El paquete no se ha podido validar.");
        }

        bool isAñadido = false;
        for (int i = 0; i < lista.Length && !isAñadido; i++) {
            if (lista[i] == null) {
                lista[i] = paquete;
                isAñadido = true;
            }
        }
    }

    void EntregaPremium(Paquete?[] lista) {
        double costoMasAlto = 0;
        foreach (var paquete in lista) {
            bool primeroEncontrado = false;
            if (paquete != null && !primeroEncontrado) {
                costoMasAlto = paquete.CalcularPrecioEnvio();
                primeroEncontrado = true;
            }

            if (paquete != null && paquete.CalcularPrecioEnvio() > costoMasAlto) {
                costoMasAlto = paquete.CalcularPrecioEnvio();
            }
        }

        for (int i = 0; i < lista.Length; i++) {
            if (lista[i] != null && lista[i]!.CalcularPrecioEnvio() == costoMasAlto) {
                Console.WriteLine(lista[i]!.ToString());
                lista[i] = null;
            }
        }
    }

    void EntregaUrgente(Paquete?[] lista) {
        for (int i = 0; i < lista.Length; i++) {
            if (lista[i] is PaqueteUrgente) {
                Console.WriteLine(lista[i]!.ToString());
                lista[i] = null;
            }
        }
    }

    void SalidaCodigo(Paquete?[] lista, string codigo) {
        for (int i = 0; i < lista.Length; i++) {
            if (lista[i] != null && lista[i]!.CodigoBarras == codigo) {
                Console.WriteLine(lista[i]!.ToString());
                lista[i] = null;
            }
        }
    }

    void GenerarInforme(Paquete?[] lista) {
        foreach (var paquete in lista) {
            if (paquete != null) {
                Console.WriteLine(paquete.ToString());
            }
        }
    }

    Paquete? RevisarValidacion(Paquete paquete) {
        try {
            if (paquete is PaqueteNormal normal) {
                var paqueteNuevoN = paqueteNormalValidator.Validate(normal);
                return paqueteNuevoN;
            }
            if (paquete is PaqueteUrgente urgente) {
                var paqueteNuevoU = paqueteUrgenteValidator.Validate(urgente);
                return paqueteNuevoU;
            }
        } catch (Exception e) {
            Console.WriteLine(e);
        }
        return null;
    }
}