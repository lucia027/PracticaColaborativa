using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ITV.Dto;
using ITV.Mapper;
using ITV.Models;
using Serilog;

namespace ITV.Storage.Xml;

public class VehiculoXmlStorage : IVehiculoXmlStorage{
    
    private readonly ILogger _logger = Log.ForContext<VehiculoXmlStorage>();

    private readonly XmlSerializerNamespaces XmlSerializerNamespaces = new();
    private readonly XmlWriterSettings XmlWriterSettings = new() {
        Indent = true,
        Encoding = Encoding.UTF8
    };

    public VehiculoXmlStorage() {
        InitStorage();
    }

    /// <inheritdoc cref="IVehiculoXmlStorage.Cargar" />
    public IEnumerable<Vehiculo> Cargar(string path) {
        if (!Path.Exists(path)) {
            _logger.Debug("Intentando salvar los datos en formato xml.");
            throw new FileNotFoundException($"El archivo con la ruta: {path} no existe");
        }

        try {
            var serializer = new XmlSerializer(typeof(List<VehiculoDto>));
            using var stream = File.OpenRead(path);
            var dtos = serializer.Deserialize(stream) as List<VehiculoDto>;

            return dtos?.Select(dto => dto.ToModel()) ?? throw new InvalidOperationException("No se han podido cargar los datos.");
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }    }

    /// <inheritdoc cref="IVehiculoXmlStorage.Salvar" />
    public void Salvar(IEnumerable<Vehiculo> items, string path) {
        try {
            var dtos = items.Select(v => v.ToDto()).ToList();
            var serializer = new XmlSerializer(typeof(List<VehiculoDto>));

            using var streamWriter = new StreamWriter(path, false, Encoding.UTF8);
            using var xmlWriter = XmlWriter.Create(streamWriter, XmlWriterSettings);
            serializer.Serialize(xmlWriter, dtos, XmlSerializerNamespaces);
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