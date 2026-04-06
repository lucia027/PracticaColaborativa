using System.Security.Cryptography;
using System.Text;
using ITV.Dto;
using ITV.Mapper;
using ITV.Models;
using Serilog;

namespace ITV.Storage.BinSec;

public class VehiculoBinStorage : IVehiculoBinStorage {

    private readonly ILogger _logger = Log.ForContext<VehiculoBinStorage>();

    public VehiculoBinStorage() {
        InitStorage();
    }

    /// <inheritdoc cref="IVehiculoBinStorage.Cargar" />
    public IEnumerable<Vehiculo> Cargar(string path) {
        if (!File.Exists(path)) {
            _logger.Debug("Intentando salvar los datos en formato bin.");
            throw new FileNotFoundException($"El archivo con la ruta: {path} no existe");
        }

        try {
            using var stream = File.OpenRead(path);
            using var reader = new BinaryReader(stream, Encoding.UTF8);

            var count = reader.ReadInt32();
            var vehiculos = new List<Vehiculo>();

            for (int i = 0; i < count; i++) {
                var v = new VehiculoDto(
                    reader.ReadInt32(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadInt32(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadBoolean()
                ).ToModel();
                vehiculos.Add(v);
            }

            return vehiculos;
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <inheritdoc cref="IVehiculoBinStorage.Salvar" />
    public void Salvar(IEnumerable<Vehiculo> items, string path) {
        try {
            using var stream = File.Create(path);
            using var writer = new BinaryWriter(stream, Encoding.UTF8);

            var dtos = items.Select(v => v.ToDto()).ToList();
            writer.Write(dtos.Count);

            foreach (var v in dtos) {
                writer.Write(v.Id);
                writer.Write(v.Matricula);
                writer.Write(v.Marca);
                writer.Write(v.Modelo);
                writer.Write(v.Cilindrada);
                writer.Write(v.Motor);
                writer.Write(v.DniDueño);
                writer.Write(v.IsDelete);
            }
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