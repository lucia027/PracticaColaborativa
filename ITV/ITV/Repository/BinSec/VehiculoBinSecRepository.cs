using ITV.Enums;
using ITV.Models;
using Serilog;

namespace ITV.Repository.BinSec;

public class VehiculoBinSecRepository : IVehiculoRepository {
    private const string FilePath = "Data/itvSecuencial.dat";

    private readonly ILogger _logger = Log.ForContext<VehiculoBinSecRepository>();

    private Dictionary<int, Vehiculo> _almacenId;
    private Dictionary<string, int> _almacenMatricula = new();
    private int _idCount;

    public VehiculoBinSecRepository() {
        if (!Directory.Exists("Data")) {
            Directory.CreateDirectory("Data");
        }

        _almacenId = LoadId();

        foreach (var v in _almacenId.Values) {
            _almacenMatricula.Add(v.Matricula, v.Id);
        }
    }

    public IEnumerable<Vehiculo> GetAll() {
        return _almacenId.Values;
    }

    public Vehiculo? GetById(int id) {
        return _almacenId.GetValueOrDefault(id);
    }

    public Vehiculo? Create(Vehiculo entity) {
        if (_almacenMatricula.ContainsKey(entity.Matricula) || _almacenId.Values.Count(v => v.DniDueño == entity.DniDueño) >= 3) {
            return null;
        }

        var vehiculo = entity with { Id = GetNewId(), IsDelete = false };
        _almacenId.Add(vehiculo.Id, vehiculo);
        _almacenMatricula.Add(vehiculo.Matricula, vehiculo.Id);

        Save();
        return vehiculo;
    }

    public Vehiculo? Update(int id, Vehiculo entity) {
        if (!_almacenId.TryGetValue(id, out var v)) {
            return null;
        }

        if (v.Matricula != entity.Matricula && _almacenMatricula.TryGetValue(entity.Matricula, out var idExistente) && idExistente != id) {
            return null;
        }
        
        var vehiculo = entity with { Id = id, IsDelete = false };
        _almacenId[id] = vehiculo;

        if (entity.Matricula != v.Matricula) {
            _almacenMatricula.Remove(v.Matricula);
            _almacenMatricula.Add(entity.Matricula, id);
        }

        Save();
        return vehiculo;
    }

    public Vehiculo? Delete(int id) {
        if (!_almacenId.TryGetValue(id, out var vehiculo)) {
            return null;
        }

        vehiculo = vehiculo with { IsDelete = true };
        _almacenId[id] = vehiculo;

        Save();
        return vehiculo;    }

    public Vehiculo? DeleteHard(int id) {
        if (!_almacenId.TryGetValue(id, out var vehiculo)) {
            return null;
        }

        _almacenId.Remove(id);
        _almacenMatricula.Remove(vehiculo.Matricula);
        
        Save();
        return vehiculo;    }

    private Dictionary<int, Vehiculo> LoadId() {
        if (!File.Exists(FilePath)) {
            return new Dictionary<int, Vehiculo>();
        }

        using var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
        using var reader = new BinaryReader(stream);

        var cantidad = reader.ReadInt32();
        _idCount = reader.ReadInt32();
        
        var vehiculos = new Dictionary<int, Vehiculo>();

        for (int i = 0; i < cantidad; i++) {
            var id = reader.ReadInt32();
            var matricula = reader.ReadString();
            var marca = reader.ReadString();
            var modelo = reader.ReadString();
            var cilindrada = reader.ReadInt32();
            var motor = Enum.TryParse(reader.ReadString(), out Motor m) ? m : Motor.Diesel;
            var dniDueño = reader.ReadString();
            var isDelete = reader.ReadBoolean();

            vehiculos[id] = new Vehiculo { Id = id, Matricula = matricula, Marca = marca, Modelo = modelo, Cilindrada = cilindrada, Motor = motor, DniDueño = dniDueño, IsDelete = isDelete };
        }

        return vehiculos;
    }
    
    private void Save() {
        using var stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
        using var writer = new BinaryWriter(stream);

        writer.Write(_almacenId.Count);
        writer.Write(GetNewId());
        foreach (var v in _almacenId.Values) {
            writer.Write(v.Id);
            writer.Write(v.Matricula);
            writer.Write(v.Marca);
            writer.Write(v.Modelo);
            writer.Write(v.Cilindrada);
            writer.Write(v.Motor.ToString());
            writer.Write(v.DniDueño);
            writer.Write(v.IsDelete);
        }
    }

    /// <summary>
    /// Devuelve un nuevo id unico.
    /// </summary>
    /// <returns>Id unico.</returns>
    private int GetNewId() {
        return _idCount++;
    }
}