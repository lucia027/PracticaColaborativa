namespace Laboratorio_Digital_del_Palacio_Interior.Models;

public record Informe {
    public Sustancia SutanciaMasUtilizada { get; init; }
    public int CasosMedicosResueltos { get; init; }
    public Sustancia SustanciaMasEfectivaTratamiento { get; init; }

    public override string ToString() {
        return $"Sustancia mas utilizada = {SutanciaMasUtilizada}, casos medicos resueltos = {CasosMedicosResueltos}, sustancias mas efectivas en tratamientos = {SustanciaMasEfectivaTratamiento}.";
    }
};