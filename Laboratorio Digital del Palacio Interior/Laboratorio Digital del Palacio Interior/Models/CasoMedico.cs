using System;
using System.Collections.Generic;
using Laboratorio_Digital_del_Palacio_Interior.Enums;

namespace Laboratorio_Digital_del_Palacio_Interior.Models;

/// <summary>
/// Representa un caso médico en el sistema.
/// </summary>
public record CasoMedico {
    public int Id { get; init; }
    public string Sintomas { get; init; } = string.Empty;
    public DateTime FechaInicio { get; init; }
    public Gravedad Gravedad { get; init; }
    public CausaSospecha CausaSospecha { get; init; }
    public HashSet<Veneno>? SustanciasSospechosas { get; init; }
    public HashSet<Medicina>? Tratamientos { get; init; }
    public EstadoCasoMedico Estado { get; init; }

    public override string ToString() {
        return $"Caso Medico => Id: {Id}, Sintomas: {Sintomas}, Fecha de inicio: {FechaInicio}, Gravedad: {Gravedad}, Causa de sospecha: {CausaSospecha}, Estado: {Estado}.";
    }
}