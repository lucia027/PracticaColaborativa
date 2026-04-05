using System.Text;
using ITV.Dto;
using ITV.Mapper;
using ITV.Models;
using Serilog;

namespace ITV.Storage.Csv;

public class VehiculoCsvStorage : IVehiculoCsvStorage {
    private readonly ILogger _logger = Log.ForContext<VehiculoCsvStorage>();

    public VehiculoCsvStorage() {
        InitStorage();
    }

    /// <inheritdoc cref="IVehiculoCsvStorage.Cargar" />
    public IEnumerable<Vehiculo> Cargar(string path) {
        if (!Path.Exists(path)) {
            throw new FileNotFoundException($"El archivo con la ruta: {path} no existe");
        }

        try {
            return File.ReadLines(path, Encoding.UTF8)
                .Skip(1)
                .Select(l => l.Split(";"))
                .Select(campos => new VehiculoDto(
                        int.Parse(campos[0]),
                        campos[1],
                        campos[2],
                        campos[3],
                        int.Parse(campos[4]),
                        campos[5],
                        campos[6],
                        bool.TryParse(campos[6], out var d) && d
                    ).ToModel()
                );
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <inheritdoc cref="IVehiculoCsvStorage.Salvar" />
    public void Salvar(IEnumerable<Vehiculo> items, string path) {
        try {
            _logger.Debug("Intentando salvar los datos en formato csv.");
            using var writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine("Id;Matricula;Marca;Modelo;Cilindrada;Motor;DniDueño;IsDelete");

            foreach (var v in items) {
                var dto = v.ToDto();
                writer.WriteLine($"{dto.Id};{dto.Matricula};{dto.Marca};{dto.Modelo};{dto.Cilindrada};{dto.Motor};{dto.DniDueño};{dto.IsDelete}");
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