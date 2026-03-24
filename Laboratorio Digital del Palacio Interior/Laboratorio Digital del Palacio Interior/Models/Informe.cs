using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public record Informe (
    string VenenoPeligroso ,
    int CasosMedicosResueltos,
    Dictionary<int, CausaSospecha> CasosMedicosVenenos,
    string AfrodisiacoIntensidad
) {
    public override string ToString() {
        return $"Veneno mas peligroso = {VenenoPeligroso}, casos medicos resueltos = {CasosMedicosResueltos}, casos medicos causados por venenos = {CasosMedicosVenenos}, afrodisiaco con la intensidad mas alta = {AfrodisiacoIntensidad}.";
    }
};