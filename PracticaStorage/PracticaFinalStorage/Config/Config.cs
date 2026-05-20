using Microsoft.Extensions.Configuration;

public static class Config {

    public static IConfiguration Configuration { get; }

    static Config() {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json",  false,  true)
            .Build();
    }

    public static string DataFolder => Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        Configuration.GetValue<string>("Repository:Directory") ?? "data"
    );

    public static string RepositoryType => Configuration.GetValue<string>("Repository:Type") ?? "memory";
    
    public static string StorageType => Configuration.GetValue<string>("Storage:Type") ?? "json";

    public static string ItvFile {
        get {
            var extension = StorageType.ToLower()switch {
                "json" => "json",
                "xml" => "xml",
                "csv" => "csv",
                "bin" => "bin",
                _ => "json"
            };
            return Path.Combine(DataFolder, $"itv.{extension}");
        }
    }
}