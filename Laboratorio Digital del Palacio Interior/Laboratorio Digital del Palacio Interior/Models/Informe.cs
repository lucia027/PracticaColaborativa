namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public record Informe (
    Sustancia SutanciaMasUtilizada,
    int CasosMedicosResueltos,
    Sustancia SustanciaMasEfectivaTratamiento
) {
    public override string ToString() {
        return $"Sustancia mas utilizada = {SutanciaMasUtilizada}, casos medicos resueltos = {CasosMedicosResueltos}, sustancias mas efectivas en tratamientos = {SustanciaMasEfectivaTratamiento}.";
    }
};