using ITV.Cache;
using ITV.Errores.Vehiculos;
using ITV.Models;
using ITV.Repository;
using ITV.Service.BakckupZip;
using ITV.Storage.Common;
using ITV.Validator.Common;
using Serilog;

namespace ITV.Service.Vehiculos;

public class VehiculoService(
    IVehiculoRepository repository,
    IStorage<Vehiculo> storage,
    IValidator<Vehiculo> validador,
    ICache<int, Vehiculo> cache,
    IVehiculoBackupService backup
    ) : IVehiculoService {
    
    private readonly ILogger _logger = Log.ForContext<VehiculoService>();
    private readonly IVehiculoBackupService _backupService = backup;
    
    public IEnumerable<Vehiculo> GetAll() {
        return repository.GetAll();
    }

    public Vehiculo GetById(int id) {
        var cached = cache.Get(id);
        if (cached != null) return cached;

        var vehiculo = repository.GetById(id) ?? throw new VehiculoException.NotFound();
        
        cache.Add(id, vehiculo);
        return vehiculo;
    }

    public Vehiculo Create(Vehiculo vehiculo) {
        throw new NotImplementedException();
    }

    public Vehiculo Update(Vehiculo vehiculo, int id) {
        throw new NotImplementedException();
    }

    public Vehiculo Delete(int id) {
        throw new NotImplementedException();
    }

    public int ImportarDatos() {
        throw new NotImplementedException();
    }

    public int ExportarDatos() {
        throw new NotImplementedException();
    }

    public string SalvarBackup() {
        throw new NotImplementedException();
    }

    public int CargarBackup() {
        throw new NotImplementedException();
    }
}