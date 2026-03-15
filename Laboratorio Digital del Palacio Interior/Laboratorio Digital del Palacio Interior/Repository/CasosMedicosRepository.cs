using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Repository;

public class CasosMedicosRepository : ICasosMedicosRepository {
    private static int _contador;
    private readonly Dictionary<int, CasoMedico> _almacenamiento = new(); 
    
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
        // ¡¡Nota!! El filtrado del if es erroneo, porque la entidad que nos pasan no tiene ID,
        // porque el repositorio es el encargado de generarlos, entonces con el ContainsKey
        // estamos buscando en el almacenamiento un ID que aún no existe.
        if (_almacenamiento.ContainsKey(entity.Id)) {
            return null;
        }
        var casoMedico = entity with { Id = _contador++ , Estado = EstadoCasoMedico.Abierto};
        _almacenamiento.Add(casoMedico.Id, casoMedico);
        
        return casoMedico;
    }

    /// <inheritdoc cref="ICasosMedicosRepository.Update"/>
    public CasoMedico? Update(int id, CasoMedico entity) {
        if (!_almacenamiento.ContainsKey(id)) {
            return null;
        }

        var casoMedicoUpdate = entity with { Id = id };
        _almacenamiento[id] = casoMedicoUpdate;
        return casoMedicoUpdate;
    }

    /// <inheritdoc cref="ICasosMedicosRepository.Delete"/>
    public CasoMedico? Delete(int id) {
        if (!_almacenamiento.TryGetValue(id, out var casoMedicoDelete)) {
            return null;
        }

        casoMedicoDelete = casoMedicoDelete with { Estado = EstadoCasoMedico.Resuelto };
        return casoMedicoDelete;
    }
}