using Biblioteca.List;

namespace Biblioteca.Repository.Common;

public interface ICrudRepository<TEntity, TKey> {
    TEntity? Create(TEntity entity);
    TEntity? Update(TEntity entity, TKey id);
    TEntity? Delete(TKey id);
    TEntity? GetById(TKey id);
    ILista<TEntity> GetAll();
}