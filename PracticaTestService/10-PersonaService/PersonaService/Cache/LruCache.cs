using Serilog;

namespace PersonaService.Cache;

/// <summary>
/// Implementación de caché basada en el algoritmo LRU (Least Recently Used).
/// </summary>
public class LruCache<TKey, TValue> : ICache<TKey, TValue> where TKey : notnull
{
    private readonly int _capacity;
    private readonly Dictionary<TKey, TValue> _data = new();
    private readonly LinkedList<TKey> _usageOrder = new();
    private readonly ILogger _logger = Log.ForContext<LruCache<TKey, TValue>>();

    public LruCache(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("La capacidad debe ser mayor que 0.", nameof(capacity));
        _capacity = capacity;
        _logger.Information("LRU Cache inicializada con capacidad: {Capacity}", capacity);
    }

    public void Add(TKey key, TValue value)
    {
        _logger.Debug("Añadiendo clave: {Key}", key);
        
        if (_data.TryGetValue(key, out _))
        {
            _data[key] = value;
            RefreshUsage(key);
            _logger.Debug("Clave {Key} actualizada", key);
            return;
        }

        if (_data.Count >= _capacity)
        {
            var oldestKey = _usageOrder.First!.Value;
            _usageOrder.RemoveFirst();
            _data.Remove(oldestKey);
            _logger.Debug("Evictado elemento más antiguo: {Key}", oldestKey);
        }

        _data.Add(key, value);
        _usageOrder.AddLast(key);
        _logger.Debug("Elemento {Key} añadido a caché", key);
    }

    public TValue? Get(TKey key)
    {
        _logger.Debug("Buscando clave: {Key}", key);
        
        if (!_data.TryGetValue(key, out var value))
        {
            _logger.Debug("Clave {Key} NO encontrada en caché", key);
            return default;
        }

        RefreshUsage(key);
        _logger.Debug("Clave {Key} encontrada en caché", key);
        return value;
    }

    public bool Remove(TKey key)
    {
        _logger.Debug("Eliminando clave: {Key}", key);
        
        if (!_data.Remove(key))
        {
            _logger.Debug("Clave {Key} no encontrada", key);
            return false;
        }

        _usageOrder.Remove(key);
        _logger.Debug("Clave {Key} eliminada correctamente", key);
        return true;
    }

    private void RefreshUsage(TKey key)
    {
        _usageOrder.Remove(key);
        _usageOrder.AddLast(key);
    }
}
