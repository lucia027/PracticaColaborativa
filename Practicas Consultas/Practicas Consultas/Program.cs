using System.Linq;
using Practicas_Consultas.Models;
using static System.Console;

var alumnos = new List<Alumno> {
    new("Juan", 7.5, "DAM"),
    new("Pedro", 8.5, "DAM"),
    new("Ana", 9.5, "DAW"),
    new("María", 8.5, "DAM"),
    new("José", 9.5, "DAW"),
    new("Alicia", 7.5, "DAW"),
    new("Alberto", 6.5, "DAM"),
    new("Amanda", 9.0, "DAW"),
    new("Carlos", 5.5, "DAM"),
    new("Carmen", 8.0, "DAW")
};


// Listado de todos los alumnos de "DAW".
var alumnosDaw = alumnos
    .Where(a => a.Curso == "DAW")
    .Select(a => a.Nombre)
    .ToList();

// Alumnos con nota superior o igual a 8.5.
var alumnosNotaSuperior = alumnos
    .Where(a => a.Nota >= 8.5)
    .Select(a => a.Nombre)
    .ToList();

// Nota media de los alumnos de "DAW".
var alumnosMediaNota = alumnos
    .Average(a => a.Nota);

// Alumnos cuyo nombre empieza por 'A'.
var alumnosNombreA = alumnos
    .Where(a => a.Nombre.Contains("a", StringComparison.CurrentCultureIgnoreCase))
    .Select(a => a.Nombre)
    .ToList();

// Agrupación de alumnos por Curso (Grupo).
var alumnosAgrupadosCurso = alumnos
    .GroupBy(a => a.Curso)
    .ToDictionary(a => a.Key);

// Alumno/s con la nota máxima (sin usar variables intermedias).
var alumnosNotaMaxima = alumnos
    .

// Listado ordenado por nota de manera descendente.
