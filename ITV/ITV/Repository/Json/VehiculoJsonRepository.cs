using System.Runtime.Versioning;
using System.Text.Json;
using ITV.Config;
using ITV.Models;
using Serilog;

namespace ITV.Repository.Json;

public class VehiculoJsonRepository : IVehiculoRepository{
    private readonly ILogger _logger = Log.ForContext<VehiculoJsonRepository>();

    private static readonly Lazy<VehiculoJsonRepository> Lazy = new(() => new VehiculoJsonRepository());
    public static VehiculoJsonRepository Instance => Lazy.Value;
    
    private Dictionary<int, Vehiculo> _almacenId = new();
    private Dictionary<string, int> _almacenMatricula = new();
    private int _idCount;
    private readonly string _filePath;

    private VehiculoJsonRepository() {
        _logger.Debug("Se esta iniciando el repositorio en Json.");
        _filePath = Path.Combine(Configuracion.DataFolder, "itv.json");
        EnsureDirectory();
        Load();
    }
    
    private readonly JsonSerializerOptions _jsonOptions = new() {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    private void EnsureDirectory() {
        var dir = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) {
            _logger.Debug("Creando directorio: {dir}", dir);
            Directory.CreateDirectory(dir);
        }
    }
    
    private void Load() {
        try {
            if (!File.Exists(_filePath)) {
                _logger.Information("El fichero de itv.json no existe.");
                return;
            }

            var json = File.ReadAllText(_filePath);
            var vehiculos = JsonSerializer.Deserialize<List<Vehiculo>>(json, _jsonOptions);
            
            if (vehiculos == null) return;

            foreach (var v in vehiculos) {
                _almacenId[v.Id] = v;
                _almacenMatricula[v.Matricula] = v.Id;
                if (v.Id > _idCount) _idCount = v.Id;
            }

            _logger.Information($"Se han cargado {_idCount} registros de vehiculos.");
        }
        catch (Exception) {
            _logger.Error("Error al cargar el archivo JSON.");
        }
    }

    private void Save() {
        try {
            var vehiculos = _almacenId.Values.ToList();
            var vehiculosJson = JsonSerializer.Serialize(vehiculos, _jsonOptions);
            File.WriteAllText(_filePath, vehiculosJson);
        } catch (Exception){
            _logger.Error("Error al salvar el archivo JSON.");
            throw;
        }
    }

    /// <inheritdoc cref="IVehiculoRepository.GetAll" />
    /// <returns></returns>
    public IEnumerable<Vehiculo> GetAll() {
        return _almacenId.Values;
    }

    /// <inheritdoc cref="IVehiculoRepository.GetById" />
    public Vehiculo? GetById(int id) {
        return _almacenId.GetValueOrDefault(id);
    }

    /// <inheritdoc cref="IVehiculoRepository.Create" />
    public Vehiculo? Create(Vehiculo entity) {
        if (_almacenMatricula.ContainsKey(entity.Matricula) || _almacenId.Values.Count(v => v.DniDueño == entity.DniDueño) >= 3) {
            _logger.Debug("No se ha podido crear el vehiculo.");
            return null;
        }

        var vehiculo = entity with { Id = GetNewId(), IsDelete = false };
        
        _almacenId.Add(vehiculo.Id, vehiculo);
        _almacenMatricula.Add(vehiculo.Matricula, vehiculo.Id);
        _logger.Debug("Vehiculo creado correctamente.");
        
        Save();
        return vehiculo;
    }

    /// <inheritdoc cref="IVehiculoRepository.Update" />
    public Vehiculo? Update(int id, Vehiculo entity) {
        if (!_almacenId.TryGetValue(id, out var viejo)) {
            return null;
        }
        if (viejo.Matricula != entity.Matricula && _almacenMatricula.TryGetValue(entity.Matricula, out var existente) && existente != id) {
            return null;
        }

        var vehiculo = entity with { Id = id, IsDelete = false };
        _almacenId[id] = vehiculo;

        if (entity.Matricula != viejo.Matricula) {
            _almacenMatricula.Remove(viejo.Matricula);
            _almacenMatricula.Add(entity.Matricula, id);
        }

        Save();
        return vehiculo;
    }

    /// <inheritdoc cref="IVehiculoRepository.Delete" />
    public Vehiculo? Delete(int id) {
        if (!_almacenId.TryGetValue(id, out var vehiculo)) {
            return null;
        }

        vehiculo = vehiculo with { IsDelete = true };
        _almacenId[id] = vehiculo;

        Save();
        return vehiculo;
    }

    /// <inheritdoc cref="IVehiculoRepository.DeleteHard" />
    public Vehiculo? DeleteHard(int id) {
        if (!_almacenId.TryGetValue(id, out var vehiculo)) {
            return null;
        }

        _almacenId.Remove(id);
        _almacenMatricula.Remove(vehiculo.Matricula);
        
        Save();
        return vehiculo;
    }
    
    /// <summary>
    /// Devuelve un nuevo id unico.
    /// </summary>
    /// <returns>Id unico.</returns>
    private int GetNewId() {
        return _idCount++;
    }
}