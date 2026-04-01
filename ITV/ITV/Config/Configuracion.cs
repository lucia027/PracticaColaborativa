using Microsoft.Extensions.Configuration;

namespace ITV.Config;

public static class Configuracion {
    private static readonly IConfiguration Config;

    static Configuracion() {
        Config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
    
    public static string DataFolder => Path.Combine(Environment.CurrentDirectory, Config.GetValue<string>("Repository:Directory") ?? "data");
    
    public static string StorageType => Config.GetValue<string>("Storage:Type") ?? "json";
    
    public static string RepositoryType {
        get {
            var type = Config.GetValue<string>("Repository:Type") ?? "memory";

            return type.ToLower() switch {
                "memory" => "memory",
                "binary" => "binary",
                "json" => "json",  
                _ => "memory"
            };
        }
    }
    
    public static string ItvFile {
        get {
            var extension = StorageType.ToLower() switch {
                "json" => "json",
                "xml" => "xml",
                "csv" => "csv",
                "bin" => "bin",
                _ => "json" // valor por defecto
            };
            return Path.Combine(DataFolder, $"itv.{extension}");
        }
    }
}