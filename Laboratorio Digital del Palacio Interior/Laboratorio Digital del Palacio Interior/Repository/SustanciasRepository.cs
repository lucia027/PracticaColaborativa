using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Repository;

/// <summary>
/// Repositorio encargado de gestionar todas las sustancias del sistema.
/// </summary>
public class SustanciasRepository : ISustanciasRepository {
        
    // Para hacerlo como un Singleton.
    private static readonly Lazy<SustanciasRepository> Lazy = new( () => new SustanciasRepository() );
    
    private static int _contador;
    private readonly Dictionary<int, Sustancia> _almacenamiento = new();
    
    // Constructor de la clase.
    public SustanciasRepository() { }

    public static SustanciasRepository Instance => Lazy.Value;
    
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
        // Se le asigna el ID a la sustancia que nos pasan antes de añadirla al diccionario
        // para poder verificar seguidamente si existe alguna sustancia con esa misma clave,
        // después de verificarlo ya si es correcto se añade al almacen.
        var sustancia = entity with { Id = _contador++ };
        
        /*
        if (_almacenamiento.ContainsKey(entity.Id)) {
            return null;
        }
        */
        
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
        if (_almacenamiento.Remove(id, out var sustanciaEliminada)) {
            return sustanciaEliminada;
        }
        return null;
    }

    /// <inheritdoc cref="ISustanciasRepository.DeleteAll" />
    public bool DeleteAll() {
        _almacenamiento.Clear();
        return true;
    }
}