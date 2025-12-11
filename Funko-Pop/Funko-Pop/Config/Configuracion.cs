using System.Globalization;

namespace Funko_Pop.Config;

/// <summary>
/// Clase estática con propiedades estáticas con la configuracion por defecto.
/// </summary>
public static class Configuracion {
    public static readonly int TamVector = 5;
    public static readonly int PorcentajeAumento = 80;
    public static readonly int PorcentajeReducir = 40;
    public static readonly CultureInfo Locale = CultureInfo.GetCultureInfo("es-ES");
}