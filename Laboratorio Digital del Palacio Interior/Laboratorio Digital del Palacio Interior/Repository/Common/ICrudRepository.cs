using System.Collections.Generic;

namespace Laboratorio_Digital_del_Palacio_Interior.Repository.Common;

/// <summary>
/// Contrato generico para las operaciones CRUD.
/// </summary>
/// <typeparam name="TKey">Tipo de la clave primaria.</typeparam>
/// <typeparam name="TEntity">Tipo de la entidad.</typeparam>
public interface ICrudRepository<TKey, TEntity> where TEntity : class {
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
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity? Delete(TKey id);
}