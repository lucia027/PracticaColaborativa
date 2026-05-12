using Microsoft.Extensions.Configuration;

namespace PracticaStorage.Config;

public static class Configuracion {
    private static readonly IConfiguration Configuration;
    
    public static string DataFolder => Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        Configuration.GetValue<string>("Repository:Directory") ?? "data"
    );
}