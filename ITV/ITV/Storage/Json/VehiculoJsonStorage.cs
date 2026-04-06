using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using ITV.Dto;
using ITV.Mapper;
using ITV.Models;
using Serilog;

namespace ITV.Storage.Json;

public class VehiculoJsonStorage : IVehiculoJsonStorage {
    private readonly ILogger _logger = Log.ForContext<VehiculoJsonStorage>();

    private readonly JsonSerializerOptions _options = new() {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter() },
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
    };
    
    public VehiculoJsonStorage() {
        InitStorage();
    }
    
    /// <inheritdoc cref="IVehiculoJsonStorage.Cargar" />
    public IEnumerable<Vehiculo> Cargar(string path) {
        if (!Path.Exists(path)) {
            _logger.Debug("Intentando salvar los datos en formato csv.");
            throw new FileNotFoundException($"El archivo con la ruta: {path} no existe");
        }

        try {
            using var stream = File.OpenRead(path);
            var dtos = JsonSerializer.Deserialize<List<VehiculoDto>>(stream, _options);

            return dtos?.Select(d => d.ToModel()) ?? throw new InvalidOperationException("No se han podido cargar los datos.");
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <inheritdoc cref="IVehiculoJsonStorage.Salvar" />
    public void Salvar(IEnumerable<Vehiculo> items, string path) {
        try {
            using var stream = File.Create(path);
            var dtos = items
                .Select(i => i.ToDto())
                .ToList();
            JsonSerializer.Serialize(stream, dtos, _options);

        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Comprueba que exista el directorio donde almacenar el archivo de datos,
    /// en caso de que no exista lo crea.
    /// </summary>
    private void InitStorage() {
        if (Directory.Exists(Config.Configuracion.DataFolder)) {
            return;
        }
        Directory.CreateDirectory("data");
    }
}