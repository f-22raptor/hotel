namespace Domain.Repositories;

public interface IBaseRepository<TEntity, in TKey>
{
    Task<ICollection<TEntity>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
        string? orderBy = null, bool isAscending = true, 
        int pageNumber = 1, int pageSize = int.MaxValue);
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<TEntity?> InsertAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(TEntity entity);
    Task<TEntity?> DeleteAsync(TKey id);
}
