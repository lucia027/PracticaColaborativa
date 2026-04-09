using System.IO.Compression;
using ITV.Config;
using ITV.Errores.Backup;
using ITV.Models;
using ITV.Storage.Common;
using Serilog;

namespace ITV.Service.BakckupZip;

public class VehiculoBackupService(
    IStorage<Vehiculo> storage
    ) : IVehiculoBackupService {
    
    private readonly string _backDirectory = Configuracion.BackupDirectory;
    private readonly ILogger _logger = Log.ForContext<VehiculoBackupService>();
    
    /// <inheritdoc cref="IVehiculoBackupService.RealizarBackup" />
    public string RealizarBackup(IEnumerable<Vehiculo> vehiculos) {
        var listaVehiculos = vehiculos.ToList();
        if (listaVehiculos.Any()) throw new BackupException.DirectoryError("No se pudo crear el directorio.");

        try {
            Directory.CreateDirectory(_backDirectory);
        } catch (Exception e) {
            Console.WriteLine(e);
            throw new BackupException.DirectoryError($"No se pudo crear el directorio: {_backDirectory}");
        }
        
        var tempDir = Path.Combine(Path.GetTempPath(), $"backup-{Guid.NewGuid()}");
        Directory.CreateDirectory(tempDir);

        try
        {
            var jsonPath = Path.Combine(tempDir, "data.json");

            try
            {
                storage.Salvar(listaVehiculos, jsonPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new BackupException.CreationError("Error al serializar los datos.");
            }

            var fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            var zipPath = Path.Combine(_backDirectory, $"{fecha}-back.zip");

            try
            {
                ZipFile.CreateFromDirectory(tempDir, zipPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new BackupException.CreationError("Error al comprimir el backup.");
            }

            return zipPath;

        } finally {
            if (Directory.Exists(tempDir)) {
                Directory.Delete(tempDir, true);
                _logger.Debug("Directorio temporal limpiado.");
            }
        }
    }

    /// <inheritdoc cref="IVehiculoBackupService.RestaurarBackup" />
    public IEnumerable<Vehiculo> RestaurarBackup(string backup) { 
        
        if (!File.Exists(backup)) {
            _logger.Warning("No se ha encontrado el archivo de backup.");
            throw new BackupException.FileNotFound(backup);
        }
        
        var tempDir = Path.Combine(Path.GetTempPath(), $"restore-{Guid.NewGuid()}");
        Directory.CreateDirectory(tempDir);
        
        try {
            try {
                ZipFile.ExtractToDirectory(backup, tempDir);
            } catch (Exception e) {
                _logger.Error(e, "Error al extraer el archivo ZIP.");
                throw new BackupException.InvalidBackupFile("No se pudo extraer el archivo.");
            }

            var jsonPath = Path.Combine(tempDir, "data.json");
            if (!File.Exists(jsonPath)) {
                _logger.Warning("El archivo de backup no contiene datos válidos (data.json no encontrado).");
                throw new BackupException.InvalidBackupFile("El archivo de backup no contiene datos válidos.");
            }

            try {
                var personas = storage.Cargar(jsonPath);
                _logger.Information("Datos extraídos del backup correctamente.");
                return personas;
            } catch (Exception e) {
                _logger.Error(e, "Error al deserializar los datos del backup.");
                throw new BackupException.InvalidBackupFile("El archivo de backup contiene datos corruptos.");
            }
        } finally {
            if (Directory.Exists(tempDir)) {
                Directory.Delete(tempDir, true);
                _logger.Debug("Directorio temporal limpiado.");
            }
        }
    }
}