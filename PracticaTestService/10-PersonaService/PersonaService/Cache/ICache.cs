namespace PersonaService.Cache;

/// <summary>
/// Interfaz para la caché.
/// </summary>
public interface ICache<TKey, TValue> where TKey : notnull
{
    void Add(TKey key, TValue value);
    TValue? Get(TKey key);
    bool Remove(TKey key);
}
