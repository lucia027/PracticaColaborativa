using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using PracticaFinalStorage.Dto;
using PracticaFinalStorage.Mapper;
using PracticaFinalStorage.Models;
using PracticaFinalStorage.Storage.Common;

namespace PracticaFinalStorage.Storage.Json;

public class CitaJsonStorage : IStorage {

    public CitaJsonStorage() {
        InitStorage();
    }

    private readonly JsonSerializerOptions _options = new() {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
    
    public void Salvar(IEnumerable<Cita> items, string path) {
        try {
            var dtos = items.Select(d => d.ToDto());
            var json = JsonSerializer.Serialize(dtos, _options);
            File.WriteAllText(path, json, new UTF8Encoding());
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<Cita> Cargar(string path) {
        if (!File.Exists(path)) throw new FileNotFoundException();
        try {
            var json = File.ReadAllText(path, Encoding.UTF8);
            var dtos = JsonSerializer.Deserialize<List<CitaDto>>(json, _options);
            if (dtos == null) throw new JsonException();
            return dtos.Select(d => d.ToModel());
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    private void InitStorage() {
        if (Directory.Exists(Config.DataFolder)) return;
        Directory.CreateDirectory("data");
    }
}