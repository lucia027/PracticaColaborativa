using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Laboratorio_Digital_del_Palacio_Interior.Config;
using Laboratorio_Digital_del_Palacio_Interior.Dto;
using Laboratorio_Digital_del_Palacio_Interior.Mappers;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Storage;

public class SustanciaJsonStorage : ISustanciaJsonStorage {

    private readonly JsonSerializerOptions _options = new() {
        WriteIndented = true, // Equivalente el PrettyPrint
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Convierte las propiedades a CamelCase en el Json
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // Ignora las propiedades que son null en el Json.
        Converters = { new JsonStringEnumConverter() }, // Para serializar las enums como string en vez de int.
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Permite caracteres especiales como el de la ñ.
    };

    public SustanciaJsonStorage() {
        InitStorage();
    }

    /// <summary>
    /// Inicia el almacenamiento asegurandose de que existe el directorio de datos.
    /// </summary>
    private void InitStorage() {
        if (Directory.Exists(Configuracion.DataFolder)) return;
        Directory.CreateDirectory("data");
    }

    /// <inheritdoc cref="ISustanciaJsonStorage.Salvar"/>
    public void Salvar(IEnumerable<Sustancia> items, string path) {
        try {
            using var stream = File.Create(path);
            var dtos = items.Select(p => p.ToDto()).ToList();
            JsonSerializer.Serialize(stream, dtos, _options);
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <inheritdoc cref="ISustanciaJsonStorage.Cargar"/>
    public IEnumerable<Sustancia> Cargar(string path) {
        if (!Path.Exists(path)) {
            throw new FileNotFoundException("No existe el archivo path.");
        }
        
        try {
            using var stream = File.OpenRead(path);
            var dtos = JsonSerializer.Deserialize<List<SustanciaDto>>(stream, _options);

            return dtos?.Select(dto => dto.ToModel()) ?? throw new InvalidOperationException("No se han podido deserializar los dto.");
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
}