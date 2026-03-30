namespace ITV.Repository.Common;

public interface ICrudRepository<in TKey, TEntity> where TEntity : class {
 
    /// <summary>
    /// Devuelve todas las entidades del almacen.
    /// </summary>
    /// <returns>Enumerable de las entidades.</returns>
    IEnumerable<TEntity> GetAll();
    
    /// <summary>
    /// Devuelve la entidad cuyo Id sea igual al proporcionado.
    /// </summary>
    /// <param name="id">Id de la entidad</param>
    /// <returns>En caso de existir la entidad y en caso contrario nulo.</returns>
    TEntity? GetById(TKey id);
    
    /// <summary>
    /// Crea y guarda en el almacen una nueva entidad.
    /// </summary>
    /// <param name="entity">Entidad nueva.</param>
    /// <returns>En caso de ser correcta la entidad y en caso contrario nulo.</returns>
    TEntity? Create(TEntity entity);
    
    /// <summary>
    /// Actualiza una entidad ya existente en el almacen.
    /// </summary>
    /// <param name="id">Id de la entidad existente.</param>
    /// <param name="entity">Entidad existente actualizada.</param>
    /// <returns>En caso de ser correcta la entidad y en caso contrario nulo.</returns>
    TEntity? Update(TKey id, TEntity entity);
    
    /// <summary>
    /// ELimina la entidad del almacen.
    /// </summary>
    /// <param name="id">Id de la entidad existente.</param>
    /// <returns>En caso de ser correcta la entidad eliminada y nulo en caso contrario.</returns>
    TEntity? Delete(TKey id);
}