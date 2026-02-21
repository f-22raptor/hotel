using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<TEntity, TKey>(AppDbContext context) : IBaseRepository<TEntity, TKey>
    where TEntity : class, IBaseModel<TKey>
    where TKey : IEquatable<TKey>
{
    public virtual async Task<ICollection<TEntity>> GetAllAsync(QueryOptions? options = null)
    {
        options ??= new QueryOptions();

        var query = ApplySorting(CustomContext(), options.Sorts);
        return await query
            .Skip((options.PageNumber - 1) * options.PageSize)
            .Take(options.PageSize)
            .ToListAsync();
    }

    public virtual Task<ICollection<TEntity>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
    {
        return GetAllAsync(new QueryOptions(pageNumber, pageSize));
    }

    public virtual async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await CustomContext()
            .FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public virtual async Task<TEntity?> InsertAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> DeleteAsync(TKey id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return null;

        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    protected abstract IQueryable<TEntity> CustomContext();

    protected virtual IQueryable<TEntity> ApplySorting(
        IQueryable<TEntity> query,
        IReadOnlyList<SortOption>? sorts)
    {
        return query;
    }
}
