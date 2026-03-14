using System.Collections.Generic;
using System.Linq;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Repository;

/// <summary>
/// Repositorio encargado de gestionar todas las sustancias del sistema.
/// </summary>
public class SustanciasRepository : ISustanciasRepository {
    private readonly Dictionary<int, Sustancia> _almacenamiento = new();
    
    /// <inheritdoc cref="ISustanciasRepository.GetAll" />
    public IEnumerable<Sustancia> GetAll() {
        return _almacenamiento.Values;
    }

    /// <inheritdoc cref="ISustanciasRepository.GetById" />
    public Sustancia? GetById(int id) {
        return _almacenamiento.GetValueOrDefault(id);
    }

    /// <inheritdoc cref="ISustanciasRepository.Create" />
    public Sustancia? Create(Sustancia entity) {
        if (_almacenamiento.ContainsKey(entity.Id)) {
            return null;
        }
        var sustancia = entity with { Id = GetId.GetNewId() };
        _almacenamiento.Add(sustancia.Id, sustancia);
        
        return sustancia;
    }

    /// <inheritdoc cref="ISustanciasRepository.Update" />
    public Sustancia? Update(int id, Sustancia entity) {
        if (!_almacenamiento.ContainsKey(entity.Id)) {
            return null;
        }

        var sustanciaUpdate = entity with { Id = id };
        _almacenamiento[id] = sustanciaUpdate;
        return sustanciaUpdate;
    }

    /// <inheritdoc cref="ISustanciasRepository.Delete" />
    public Sustancia? Delete(int id) {
        throw new System.NotImplementedException();
    }
}