using Serilog;

namespace ITV.Cache;

/// <summary>
/// Caché Lru con capacidad fija.
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public class Cache<TKey, TValue> : ICache<TKey, TValue> where TKey: notnull {

    private readonly ILogger _logger = Log.ForContext<Cache<TKey, TValue>>();
    
    private readonly int _capacidad;
    private readonly Dictionary<TKey, TValue> _datos = new();
    private readonly LinkedList<TKey> _ordenUso = new();

    public Cache(int capacidad) {
        if (capacidad <= 0) {
            throw new ArgumentException("La capacidad de la cache no puede ser menor o igual a 0.");
        }
        _capacidad = capacidad;
    }
    
    /// <inheritdoc cref="ICache{TKey,TValue}.Add" />
    public void Add(TKey key, TValue value) {
        if (_datos.TryGetValue(key, out var valor)) {
            _logger.Debug($"La clave proporcionada ya existe, se actualizara el valor para la clave: {key}");
            
            _datos[key] = value;
            RefreshUsage(key);
            return;
        }
        
        if (_datos.Count >= _capacidad) {
            var claveVieja = _ordenUso.First!.Value;
            var valorViejo = _datos[claveVieja];
            
            _logger.Debug($"La cache esta llena, se esta eliminando el elemento mas viejo con clave: {claveVieja} y valor: {valorViejo}");
            
            _ordenUso.RemoveFirst();
            _datos.Remove(claveVieja);
        }

        _datos.Add(key, value);
        _ordenUso.AddLast(key);
        _logger.Debug($"Se ha añadido un elemento nuevo, lista de orden de uso: {_ordenUso}");
    }

    /// <inheritdoc cref="ICache{TKey,TValue}.Get" />
    public TValue? Get(TKey key) {
        if (!_datos.TryGetValue(key, out var value)) {
            _logger.Debug($"No se ha enconctrado la clave: {key} en la cache.");
            return default;
        }

        _logger.Debug($"Se ha enconctrado la clave: {key} en la cache.");
        RefreshUsage(key);

        return value;
    }

    /// <inheritdoc cref="ICache{TKey,TValue}.Remove" />
    public bool Remove(TKey key) {
        if (!_datos.Remove(key)) {
            _logger.Debug($"No se ha enconctrado la clave: {key} en la cache.");
            return false;
        }

        _ordenUso.Remove(key);
        _logger.Debug($"Se ha eliminado la clave: {key} correctamente de la cache.");
        return true;    
    }

    /// <inheritdoc cref="ICache{TKey,TValue}.DisplayStatus" />
    public void DisplayStatus() {
        _logger.Information($"Capacidad disponible en la cache: {_datos.Count - _capacidad}");
        _logger.Information($"Uso de la cache del menos reciente al mas reciente: {_ordenUso}");    
    }
    
    /// <summary>
    /// Desplaza la clave existente a la ultima posicion de la lista de orden de uso.
    /// </summary>
    /// <param name="key">Clave del elemento.</param>
    private void RefreshUsage(TKey key) {
        _logger.Verbose($"Moviendo la clave: {key} al final de la lista.");
        _ordenUso.Remove(key);
        _ordenUso.AddLast(key);
    }
}