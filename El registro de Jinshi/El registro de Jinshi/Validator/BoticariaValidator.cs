using El_registro_de_Jinshi.Models;

namespace El_registro_de_Jinshi.Validator;

public class BoticariaValidator {
    public Boticaria Validate(Boticaria boticaria) {
        if (string.IsNullOrEmpty(boticaria.Nombre)) {
            throw new ArgumentException("El nombre no puede estar vacio o ser nulo.");
        }
        if (boticaria.Edad > 0) {
            throw new ArgumentException("La edad no puede ser negativa.");
        }
        if (string.IsNullOrEmpty(boticaria.Rol)) {
            throw new ArgumentException("El rol no puede estas vacio o ser nulo.");
        }
        if (boticaria.Especialidad != Especialidad.Analisis || boticaria.Especialidad != Especialidad.Hierbas || boticaria.Especialidad != Especialidad.Venenos) {
            throw new ArgumentException("La especialidad no puede ser algo diferente de hiervas, analista o venenos.");
        }
        return boticaria;
    }
}