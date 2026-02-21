namespace Domain.Repositories;

public interface IBaseRepository<TEntity, in TKey>
{
    Task<ICollection<TEntity>> GetAllAsync(QueryOptions? options = null);
    Task<ICollection<TEntity>> GetAllAsync(int pageNumber = 1, int pageSize = 10);
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<TEntity?> InsertAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(TEntity entity);
    Task<TEntity?> DeleteAsync(TKey id);
}
