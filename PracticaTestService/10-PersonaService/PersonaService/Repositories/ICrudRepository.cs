namespace PersonaService.Repositories;

/// <summary>
/// Interfaz genérica para operaciones CRUD.
/// </summary>
public interface ICrudRepository<in TKey, TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(TKey id);
    TEntity? Create(TEntity entity);
    TEntity? Update(TKey id, TEntity entity);
    TEntity? Delete(TKey id, bool logical = true);
}
