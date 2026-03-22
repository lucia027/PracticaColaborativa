using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Repository;

public class CasosMedicosRepository : ICasosMedicosRepository {
    
    // Para hacerlo como un Singleton.
    private static readonly Lazy<CasosMedicosRepository> Lazy = new( () => new CasosMedicosRepository() );
    
    private static int _contador;
    private readonly Dictionary<int, CasoMedico> _almacenamiento = new();

    // Constructor de la clase.
    public CasosMedicosRepository() { }

    public static CasosMedicosRepository Instance => Lazy.Value;
    
    /// <inheritdoc cref="ICasosMedicosRepository.GetAll"/>
    public IEnumerable<CasoMedico> GetAll() {
        return _almacenamiento.Values;
    }

    /// <inheritdoc cref="ICasosMedicosRepository.GetById"/>
    public CasoMedico? GetById(int id) {
        return _almacenamiento.GetValueOrDefault(id);
    }

    /// <inheritdoc cref="ICasosMedicosRepository.Create"/>
    public CasoMedico? Create(CasoMedico entity) {
        // Se le asigna el ID al caso médico que nos pasan antes de añadirlo al diccionario
        // para poder verificar seguidamente si existe algún caso médico con esa misma clave,
        // después de verificarlo ya si es correcto se añade al almacen.
        var casoMedico = entity with { Id = _contador++ , FechaInicio = DateTime.Now};
        /*
        if (_almacenamiento.ContainsKey(entity.Id)) {
            return null;
        }
        */
        
        _almacenamiento.Add(casoMedico.Id, casoMedico);
        
        return casoMedico;
    }

    /// <inheritdoc cref="ICasosMedicosRepository.Update"/>
    public CasoMedico? Update(int id, CasoMedico entity) {
        if (!_almacenamiento.ContainsKey(id)) {
            return null;
        }

        var casoMedicoUpdate = entity with { Id = id , FechaInicio = DateTime.Now};
        _almacenamiento[id] = casoMedicoUpdate;
        return casoMedicoUpdate;
    }

    /// <inheritdoc cref="ICasosMedicosRepository.Delete"/>
    public CasoMedico? Delete(int id) {
        if (!_almacenamiento.TryGetValue(id, out var casoMedicoDelete) || casoMedicoDelete.Estado == EstadoCasoMedico.Resuelto) {
            return null;
        }

        casoMedicoDelete = casoMedicoDelete with { Estado = EstadoCasoMedico.Resuelto };
        _almacenamiento[id] = casoMedicoDelete;
        return casoMedicoDelete;
    }
    
    /// <inheritdoc cref="ICasosMedicosRepository.DeleteAll"/>
    public bool DeleteAll() {
        _almacenamiento.Clear();
        return true;
    }
}