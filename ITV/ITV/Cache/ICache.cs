namespace ITV.Cache;

/// <summary>
/// Contrato generico para la cache.
/// </summary>
/// <typeparam name="TKey">Clave proporcionada.</typeparam>
/// <typeparam name="TValue">Valor proporcionado.</typeparam>
public interface ICache<in TKey, TValue> where TKey : notnull {
    void Add(TKey key, TValue value);
    TValue? Get(TKey key);
    bool Remove(TKey key);
    void DisplayStatus();
}