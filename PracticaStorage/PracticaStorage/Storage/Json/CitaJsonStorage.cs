using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Itv.Models;
using PracticaStorage.Config;
using PracticaStorage.Dto;
using PracticaStorage.Mappers;
using Serilog;

namespace PracticaStorage.Storage.Json;

public class CitaJsonStorage : ICitaStorage {

    private ILogger _logger = Log.ForContext<CitaJsonStorage>();
    
    private readonly JsonSerializerOptions _options = new() {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter() },
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
    };

    public CitaJsonStorage() {
        InitStorage();
    }

    public void Salvar(IEnumerable<Cita> items, string path) {
        try {
            var dtos = items.Select(d => d.ToDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, _options);
            File.WriteAllText(path, json, new UTF8Encoding(false));
        } catch (Exception e)  {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<Cita> Cargar(string path) {
        if (!File.Exists(path)) throw new FileNotFoundException();

        try {
            var json = File.ReadAllText(path);
            var dtos = JsonSerializer.Deserialize<List<CitaDto>>(json, _options);
            if (dtos == null) throw new JsonException();
            var items = dtos.Select(d => d.ToModel());
            
            return items;
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    private void InitStorage() {
        if(Directory.Exists(Configuracion.DataFolder)) return;
        Directory.CreateDirectory("data");
    }
}